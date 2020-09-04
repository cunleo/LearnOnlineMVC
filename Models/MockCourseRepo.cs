using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearnOnline.Models
{
    public class MockCourseRepo : ICourseRepo
    {
        ICategoryRepo _category;

        public MockCourseRepo(ICategoryRepo category)
        {
            _category = category;
        }
      
        public IEnumerable<Course> AllCourses => new List<Course> { 
                new Course { CourseId=1,Title="ASP.Core",Description="An implementation of ASP .NET Core",
                Duration="2 months", Fee=2300, ImageUrl="", Active=true, Category=_category.AllCategories.ToList()[0]
            },
                new Course { CourseId=2,Title="Data Structure 2.0",Description="Fundamentals of data structure",
                Duration="1 months", Fee=1700, ImageUrl="", Active=true, Category=_category.AllCategories.ToList()[0]
            },
                new Course { CourseId=3,Title="Accessment of IQ",Description="A complete study of behavioural pattern as related to IQ",
                Duration="4 months", Fee=6100, ImageUrl="", Active=true, Category=_category.AllCategories.ToList()[1]
            },
                   new Course { CourseId=4,Title="Music as Art",Description="A music composition for beginners",
                Duration="1 months", Fee=500, ImageUrl="", Active=true, Category=_category.AllCategories.ToList()[2]
            },
                 new Course { CourseId=5,Title="Programming VB 6.0",Description="VB UI/UX",
                Duration="1 months", Fee=1500, ImageUrl="", Active=false, Category=_category.AllCategories.ToList()[0]
            }};


        public Course GetCourseById(int courseId)
        {
           return AllCourses.Where(a => a.CourseId == courseId).FirstOrDefault();
            // also works
            //return AllCourses.FirstOrDefault(a => a.CourseId == courseId);
        }
    }
}
