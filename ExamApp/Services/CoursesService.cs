using ExamApp.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamApp.Services
{
    public class CoursesService : ICoursesService
    {
        public IEnumerable<Course> GetCourses()
        {
            var ctx = new MainContext();

            var courses = ctx.Courses
                .ToArrayAsync()
                .Result
                .AsEnumerable();

            courses.OrderBy(c => c.Title);

            return courses;
        }

        public Course GetCourse(Guid id)
        {
            var ctx = new MainContext();

            return ctx.Courses
                .Include(x => x.Students)
                .FirstOrDefault(x => x.Id == id);
        }

        public async Task ModifyCourse(Guid id, Course course)
        {
            var ctx = new MainContext();

            course.Id = id;

            ctx.Attach(course).State = EntityState.Modified;
            await ctx.SaveChangesAsync();
        }
    }
}
