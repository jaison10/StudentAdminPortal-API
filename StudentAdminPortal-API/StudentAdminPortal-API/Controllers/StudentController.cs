using Microsoft.AspNetCore.Mvc;
using StudentAdminPortal_API.Repositories;

namespace StudentAdminPortal_API.Controllers
{
    [ApiController]
    public class StudentController : Controller
    {
        private readonly IStudentRepository studentRepository;

        public StudentController(IStudentRepository studentRepository)
        {
            this.studentRepository = studentRepository;
        }

        [HttpGet]
        [Route("[controller]")] //name for which route this has to be executed. 
        public IActionResult GetAllStudents()
        {
            return Ok(studentRepository.GetStudents());
        }
    }
}
