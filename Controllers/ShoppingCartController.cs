using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LearnOnline.Models;
using Microsoft.AspNetCore.Mvc;

namespace LearnOnline.Controllers
{
    public class ShoppingCartController : Controller
    {

        private readonly ICourseRepo course;
        private readonly EFShoppingCartRepo shoppingCartRepo;


        public ShoppingCartController(ICourseRepo courseRepo , EFShoppingCartRepo cart)
        {
            course = courseRepo;
            shoppingCartRepo = cart;
        }
        public IActionResult Index()
        {

            shoppingCartRepo.shoppingCartItems = shoppingCartRepo.GetshoppingCartItems();

            return View(shoppingCartRepo);
        }

        public RedirectToActionResult AddToShoppingCart(int courseId)
        {
            var selectedCourse = course.GetCourseById(courseId);
            shoppingCartRepo.AddItemToCart(selectedCourse, selectedCourse.Fee);
            return RedirectToAction("Index");
        }

        public RedirectToActionResult RemoveFromShoppingCart(int courseId)
        {
            var selectedCourse = course.GetCourseById(courseId);
            shoppingCartRepo.RemoveItemFromCart(selectedCourse);
            return RedirectToAction("Index");
        }
    }
}
