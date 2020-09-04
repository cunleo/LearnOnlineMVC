using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace LearnOnline.Models
{
    public  class EFCourseRepo : ICourseRepo
    {

        private readonly AppsContext _dbContext;
        public EFCourseRepo(AppsContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Course> AllCourses
        {
            get
            { 
                return _dbContext.courses.Include(a => a.Category); 
            }
        }

        public Course GetCourseById(int courseId)
        {
            return _dbContext.courses.Include(a => a.Category).First(a=>a.CourseId==courseId);
           
        }
    }
}
