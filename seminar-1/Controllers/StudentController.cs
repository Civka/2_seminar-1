using Microsoft.AspNetCore.Mvc;
using seminar_1.Data;

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

        /**
        [HttpPost]
        [Route("Create")]

        public IActionResult PostCreate()
        {

        }
        */
    }
}
