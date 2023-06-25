using Microsoft.AspNetCore.Mvc;
using StudentAdminPortal_API.Models;
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
            var students = studentRepository.GetStudents(); //getting list of all students from db
            
            var modelStudents = new List<Student>(); //list of type of Model

            foreach (var student in students)
            {
                modelStudents.Add(new Student() //creating object of Model in every loop and add that to list.
                {
                    Id = student.Id,
                    firstname = student.firstname,
                    lastname = student.lastname,
                    DOB = student.DOB,
                    Email = student.Email,
                    Mobile = student.Mobile,
                    ProfileImgUrl = student.ProfileImgUrl,
                    GenderID = student.GenderID
                });
            }
            return Ok(modelStudents);
        }
    }
}
