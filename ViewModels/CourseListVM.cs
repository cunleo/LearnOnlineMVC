using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LearnOnline.Models;

namespace LearnOnline.ViewModels
{
    public class CourseListVM
    {
        public IEnumerable<Course> Courses { get; set; }
        public string SelectedCategory { get; set; }
        
    }
}
