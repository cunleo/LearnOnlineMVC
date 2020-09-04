
using System.Linq;
using LearnOnline.Models;
using LearnOnline.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace LearnOnline.Controllers
{
    public class CourseController : Controller
    {
        ICategoryRepo _categoryRepo;
        ICourseRepo _courseRepo;

        public CourseController(ICourseRepo courseRepo, ICategoryRepo categoryRepo)
        {
            _categoryRepo = categoryRepo;
            _courseRepo = courseRepo;

        }
        //public IActionResult Index()
        //{
        //    return View();
        //}
       public ViewResult List()
        {
            CourseListVM courseListVM = new CourseListVM() { Courses = _courseRepo.AllCourses.Where<Course>(a=>a.Active==true), SelectedCategory =_categoryRepo.AllCategories.ToList()[0].Name};
            return View(courseListVM);
        }
        
        public IActionResult Details(int id)
        {
          //  if (id > 0) id = 1;
            
                Course course = _courseRepo.GetCourseById(id);
                return View(course);
          
        }

    }
}
