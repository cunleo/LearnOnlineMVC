using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearnOnline.Models
{
    public interface ICourseRepo
    {
        IEnumerable<Course> AllCourses { get; }
        Course GetCourseById(int courseId);

    }
}
