using System;
using System.Linq;
using ExamApp.Context;
using ExamApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace ExamApp.Controllers;

[ApiController]
[Route("students")]
public class StudentsController : ControllerBase
{
    private IStudentsService _service;

    public StudentsController(IStudentsService service)
    {
        _service = service;
    }

    [HttpGet]
    [Route("getAll")]
    public IActionResult GetAll()
    {
        return Ok(_service.GetAllStudents());
    }

    [HttpGet]
    [Route("get")]
    public IActionResult Get(int id)
    {
        return Ok(_service.GetAllStudents().First(x => x.Id == id));
    }

    [HttpPost]
    [Route("create")]
    public IActionResult Create(Student student)
    {
        return Ok(_service.AddStudent(student));
    }

    [HttpPost]
    [Route("update")]
    public IActionResult Update(int id, Student student)
    {
        _service.Modify(id, student);
        return Ok();
    }
}