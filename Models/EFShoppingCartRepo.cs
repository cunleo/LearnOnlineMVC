using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace LearnOnline.Models
{
    public class EFShoppingCartRepo 
    {
        private readonly AppsContext _appsContext;
        private string shoppingCartId { get; set; }
        public List<ShoppingCartItem> shoppingCartItems { get; set; }

        public EFShoppingCartRepo(AppsContext appsContext)
        {
            _appsContext = appsContext;

        }
       
      public static EFShoppingCartRepo GetShoppingCart(IServiceProvider serviceProvider)
        {
            ISession session = serviceProvider.GetRequiredService<IHttpContextAccessor>().HttpContext.Session;
            string _ShoppingCartId = session.GetString("ShoppingCartId") ?? Guid.NewGuid().ToString();

            session.SetString("ShoppingCartId", _ShoppingCartId);
            var context = serviceProvider.GetService<AppsContext>();
            return new EFShoppingCartRepo(context) { shoppingCartId = _ShoppingCartId };

        }
        public void AddItemToCart(Course ocourse, decimal amount)
        {
            var oShoppinCartItem = _appsContext.shoppingCartItems.SingleOrDefault(
                a=>a.course.CourseId== ocourse.CourseId
                &&
                a.ShoppingCartId== shoppingCartId
                );

            if (oShoppinCartItem == null)
            {
                oShoppinCartItem = new ShoppingCartItem { 
                    ShoppingCartId = shoppingCartId, 
                    course = ocourse,
                    Amount = amount 
                };

                _appsContext.shoppingCartItems.Add(oShoppinCartItem);

            } else
            {
                //do nothing 
            }
            _appsContext.SaveChanges();
        }
          

        public void RemoveItemFromCart(Course course)
        {
            var oShoppinCartItem = _appsContext.shoppingCartItems.SingleOrDefault(
                           a => a.course.CourseId == course.CourseId
                           &&
                           a.ShoppingCartId == this.shoppingCartId
                           );
            if (oShoppinCartItem != null)
            {
                _appsContext.shoppingCartItems.Remove(oShoppinCartItem);
            }
            else
            {
                //do nothing, no course exist 
            }
            _appsContext.SaveChanges();
        }

        public List<ShoppingCartItem> GetshoppingCartItems()
        {
            var oShoppinCartItem = _appsContext.shoppingCartItems.Where(c => c.ShoppingCartId == this.shoppingCartId)
                .Include(cart => cart.course).ToList();

            return oShoppinCartItem;

        }
        public decimal GetShoppingCartTotal()
        {
            return _appsContext.shoppingCartItems.Where(c => c.ShoppingCartId == this.shoppingCartId).Select(c => c.Amount).Sum();

        }

        public void ClearShoppingCart()
        {
            var oShoppinCartItem = _appsContext.shoppingCartItems.Where(c => c.ShoppingCartId == this.shoppingCartId);

            _appsContext.shoppingCartItems.RemoveRange(oShoppinCartItem);
            _appsContext.SaveChanges();
        }
    }
}
