using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamApp.Services
{
    public interface IStudentsService
    {
        /* Performance: IQueryable is faster than IEnumerable. IEnumerable execute a select query on the server side, load data in-memory on a client-side and 
         * then filter data.However IQueryable execute the select query on the server side with all filters. */
        IQueryable<Student> GetAllStudents();
        Task AddStudent(Student student);
        void Modify(int id, Student student);
       
    }
}
