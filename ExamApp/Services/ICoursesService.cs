using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExamApp.Services
{
    public interface ICoursesService
    {
        IEnumerable<Course> GetCourses();
        Course GetCourse(Guid id);

        /* Changing Modify to an async method because application need not to wait for the response after Modify and can continue other task*/
        Task ModifyCourse(Guid id, Course course);
    }
}
