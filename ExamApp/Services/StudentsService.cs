using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExamApp.Context;
using Microsoft.EntityFrameworkCore;

namespace ExamApp.Services;
public class StudentsService : IStudentsService
{
    public IQueryable<Student> GetAllStudents()
    {
        var ctx = new MainContext();
        return ctx.Students.AsQueryable<Student>();
    }

    public async Task AddStudent(Student student)
    {
        var ctx = new MainContext();

        if (student.Age < 18)
        {
            throw new Exception();
        }

       await ctx.Students.AddAsync(student);
       await ctx.SaveChangesAsync();
    }

    public void Modify(int id, Student student)
    {
        var ctx = new MainContext();

        if (student.Age < 18)
        {
            throw new Exception();
        }
            
        student.Id = id;

        ctx.Attach(student).State = EntityState.Modified;
        ctx.SaveChanges();
    }
    
}