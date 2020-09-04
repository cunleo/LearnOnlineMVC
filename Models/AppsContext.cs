using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace LearnOnline.Models
{
    public class AppsContext: DbContext
    {
        public DbSet<Course> courses { get; set; }
        public DbSet<Category> categories { get; set; }

        public DbSet<ShoppingCartItem> shoppingCartItems { get; set; }

        public AppsContext(DbContextOptions<AppsContext> options)
            : base(options)
        {
         
        }


      

    }
}
