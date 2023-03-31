using MethodTimer;
using Microsoft.AspNetCore.Mvc;
using seminar_1.Data;
using seminar_1.Data.DTO;
using seminar_1.Data.Model;
using System.Linq;

namespace seminar_1.Controllers
{
    [ApiController]
    [Route("Students")]
    public class StudentController : Controller
    {
        private ApplicationDbContext _context;

        public StudentController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("List")]
        public IActionResult GetList()
        {
            var result = _context.Students.ToList();
            return new JsonResult(result);
        }

        [HttpGet]
        [Route("First")]

        public IActionResult GetFirst() {

            var result = _context.Students.FirstOrDefault();
            return new JsonResult(result);
        }

        [HttpGet]
        [Route("Top")]

        public IActionResult GetTop(int topCount, string? orderBy = "LastName")
        {
            if (topCount <= 0)
            {
                return BadRequest();
            }

            if (orderBy == "FirstName")
            {
                return new JsonResult(_context.Students.Take(topCount).OrderBy(x => x.FirstName).ToList());
            }    
            else
            {
                return new JsonResult(_context.Students.Take(topCount).OrderBy(x => x.LastName).ToList());
            }
            
        }


       /*
        [HttpPost]
        [Route("Add")]

        public IActionResult PostAdd(List<Students> students)
        {
          
            foreach (var student in students)
            {
                bool duplicate = _context.Students.Where(x => x.FirstName == student.FirstName && x.LastName == student.LastName).Any();
                if (duplicate) continue;

                    _context.Students.Add(student);                     
                    _context.SaveChanges();
                
            }
            return Ok(students);
        }
       */

        [Time]
        [HttpPost]
        [Route("Import")]

        public IActionResult PostImport(List<StudentDto> studentsDto)
        {
            foreach (var studentDto in studentsDto)
            {
                bool duplicate = _context.Students.Where(x => x.ExternalId == studentDto._id).Any();
                if (duplicate) continue;

                var student = new Students()
                {
                    ExternalId = studentDto._id,
                    About = studentDto.about,
                    FirstName = studentDto.name.Split(' ')[0],
                    LastName = studentDto.name.Split(' ')[1],
                    Email = studentDto.email           
                };

                _context.Students.Add(student); // přidání do databáze
            }
            _context.SaveChanges();
            return Ok();
        }
    }
}
