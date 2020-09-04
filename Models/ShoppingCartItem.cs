using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearnOnline.Models
{
    public class ShoppingCartItem
    {
        public int ShoppingCartItemId { get; set; }
        public Course course { get; set; }
        public decimal Amount { get; set; }
        public string ShoppingCartId { get; set; }
    }
}
