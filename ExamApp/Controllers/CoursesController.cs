using System;
using System.Linq;
using ExamApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace ExamApp.Controllers;

public class CoursesController: ControllerBase
{
    private ICoursesService _coarseservice;
    private IStudentsService _studentsservice;

    public CoursesController(IStudentsService studentService, ICoursesService coarseService)
    {
        _coarseservice = coarseService;
        _studentsservice = studentService;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(_coarseservice.GetCourses());
    }

    [HttpPost]
    public IActionResult AddStudentToCourse(int studentId, Guid courseId)
    {
        var course = _coarseservice.GetCourse(courseId);
        var student = _studentsservice.GetAllStudents()
            .FirstOrDefault(x => x.Id == studentId);

        if (student == null || student.Age < 18)
        {
            throw new Exception();
        }

        course.Students.Add(student);
        _coarseservice.ModifyCourse(courseId, course);

        return Ok();
    }
}
