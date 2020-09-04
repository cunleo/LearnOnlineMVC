using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace LearnOnline.Models
{
    public class EFCategoryRepo: ICategoryRepo
    {
        private readonly AppsContext _dbContext;
        public EFCategoryRepo(AppsContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Category> AllCategories => _dbContext.categories;
    }
}
