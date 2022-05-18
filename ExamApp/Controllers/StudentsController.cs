using System.Linq;
using ExamApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace ExamApp.Controllers;

[ApiController]
[Route("students")]
public class StudentsController : ControllerBase
{
    private IStudentsService _service;
    private ILogging _logger;

    public StudentsController(IStudentsService service, ILogging logger)
    {
        _service = service;
        _logger = logger;
    }

    [HttpGet]
    [Route("getAll")]
    public IActionResult GetAll()
    {
        _logger.Info(System.DateTime.Now.ToString() + ": Getting All Student List");
        return Ok(_service.GetAllStudents());
    }

    [HttpGet]
    [Route("get")]
    public IActionResult Get(int id)
    {
        _logger.Info(System.DateTime.Now.ToString() + ": Getting Student for id = " + id);
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