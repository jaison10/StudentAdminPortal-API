using Microsoft.AspNetCore.Mvc;
using StudentAdminPortal_API.Models;
using StudentAdminPortal_API.Repositories;
using System.Net.NetworkInformation;

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
            //the above is Data model -data from server. This we arent exposing to the user.

            var modelStudents = new List<Student>(); //list of type of Model

            foreach (var student in students)
            {
                //below is Domain Model which will be exposed to the user.
                modelStudents.Add(new Student() //creating object of Model in every loop and add that to list.
                {
                    Id = student.Id,
                    firstname = student.firstname,
                    lastname = student.lastname,
                    DOB = student.DOB,
                    Email = student.Email,
                    Mobile = student.Mobile,
                    ProfileImgUrl = student.ProfileImgUrl,
                    GenderID = student.GenderID,
                    //Gender = student.Gender,   //this will data model in the form of an object.
                    //Address = student.Address
                    Gender = new Gender()        //coverting the data model to Domain model
                    {
                        Id = student.Gender.Id,
                        Description = student.Gender.Description
                    },
                    Address = new Address()     //coverting the data model to Domain model
                    {
                        Id = student.Address.Id,
                        PhysicalAddress = student.Address.PhysicalAddress,
                        PostalAddress = student.Address.PostalAddress,
                        StudentID = student.Address.StudentID
                    }
                });
            }
            return Ok(modelStudents);
        }
    }
}
