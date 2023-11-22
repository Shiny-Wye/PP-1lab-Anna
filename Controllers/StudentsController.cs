using PP_1lab_Anna.Database;
using PP_1lab_Anna.Interfaces.StudentsInterfaces;
using PP_1lab_Anna.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;
using PP_1lab_Anna.Filters;

namespace PP_1lab_Anna.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentsController : ControllerBase
    {
        private readonly ILogger<StudentsController> _logger;
        private readonly IStudentService _studentService;
        private StudentDbContext _context;

        public StudentsController(ILogger<StudentsController> logger, IStudentService studentService, StudentDbContext context)
        {
            _logger = logger;
            _studentService = studentService;
            _context = context;
        }

     
        [HttpPost(Name = "GetStudentsByGroup")]
        public async Task<IActionResult> GetStudentsByGroupAsync(StudentGroupFilter filter, CancellationToken cancellationToken = default)
        {
            var students = await _studentService.GetStudentsByGroupAsync(filter, cancellationToken);

            return Ok(students);
        }

        [HttpPost("AddStudent", Name = "AddStudent")]
        public IActionResult CreateStudent([FromBody] PP_1lab_Anna.Models.Student student)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Students.Add(student);
            _context.SaveChanges();
            return Ok(student);
        }

        [HttpPut("EditStudent")]
        public IActionResult UpdateStudent(string firstname, [FromBody] Student updatedStudent)
        {
            var existingStudent = _context.Students.FirstOrDefault(g => g.FirstName == firstname);

            if (existingStudent == null)
            {
                return NotFound();
            }

            existingStudent.FirstName = updatedStudent.FirstName;
            existingStudent.LastName = updatedStudent.LastName;
            existingStudent.MiddleName = updatedStudent.MiddleName;
            existingStudent.GroupId = updatedStudent.GroupId;
            _context.SaveChanges();

            return Ok();
        }

        [HttpPost("AddGroup", Name = "AddGroup")]
        public IActionResult CreateGroup([FromBody] PP_1lab_Anna.Models.Group group)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Groups.Add(group);
            _context.SaveChanges();
            return Ok(group);
        }

        [HttpPut("EditGroup")]
        public IActionResult UpdateGroup(string groupname, [FromBody] StudentGroupFilter updatedGroup)
        {
            var existingGroup = _context.Groups.FirstOrDefault(g => g.GroupName == groupname);

            if (existingGroup == null)
            {
                return NotFound();
            }

            existingGroup.GroupName = updatedGroup.GroupName;
            _context.SaveChanges();

            return Ok();
        }

        [HttpDelete("DeleteGroup")]
        public IActionResult DeleteGroup(string groupName, PP_1lab_Anna.Models.Group updatedGroup)
        {
            var existingGroup = _context.Groups.FirstOrDefault(g => g.GroupName == groupName);

            if (existingGroup == null)
            {
                return NotFound();
            }
            _context.Groups.Remove(existingGroup);
            _context.SaveChanges();

            return Ok();
        }

        //[HttpDelete("DeleteGroup")]
        //public IActionResult DeleteStudent(string firstName, PP_1lab_Anna.Models.Student updatedStudent)
        //{
        //    var existingStudent = _context.Students.FirstOrDefault(g => g.FirstName == firstName);

        //    if (existingStudent == null)
        //    {
        //        return NotFound();
        //    }
        //    _context.Students.Remove(existingStudent);
        //    _context.SaveChanges();

        //    return Ok();
        //}
    }
}
