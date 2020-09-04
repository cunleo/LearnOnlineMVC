using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearnOnline.Models
{
    public class MockCategoryRepo : ICategoryRepo
    {
  
        public IEnumerable<Category> AllCategories => new List<Category>{
            new Category {
                CategoryId = 1,
                Name = "Technology",
                Description = "Technology Related Courses" },
             new Category { CategoryId = 2, Name = "Social Science", Description = "Social Science Courses" },
             new Category { CategoryId = 3, Name = "Arts", Description = "Art Courses" }
        };

    }

}