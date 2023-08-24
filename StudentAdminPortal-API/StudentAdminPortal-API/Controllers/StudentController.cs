using Microsoft.AspNetCore.Mvc;
using DomainModels = StudentAdminPortal_API.DomainModels;
using StudentAdminPortal_API.Repositories;
using System.Net.NetworkInformation;
using AutoMapper;
using StudentAdminPortal_API.DomainModels;

namespace StudentAdminPortal_API.Controllers
{
    [ApiController]
    public class StudentController : Controller
    {
        private readonly IStudentRepository studentRepository;
        private readonly IMapper mapper;
        private RouteAttribute routeAttribute;

        public StudentController(IStudentRepository studentRepository, IMapper mapper)
        {
            this.studentRepository = studentRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        [Route("[controller]")] //name for which route this has to be executed. 
        public async Task<IActionResult> GetAllStudents()
       {
            var students = await studentRepository.GetStudents(); //getting list of all students from db
            //the above is Data model -data from server. This we arent exposing to the user. Instead converting to DomainModel

            //var modelStudents = new List<DomainModels.Student>(); //list of type of Model

            //foreach (var student in students)
            //{
            //    //below is Domain Model which will be exposed to the user.
            //    modelStudents.Add(new DomainModels.Student() //creating object of Model in every loop and add that to list.
            //    {
            //        Id = student.Id,
            //        firstname = student.firstname,
            //        lastname = student.lastname,
            //        DOB = student.DOB,
            //        Email = student.Email,
            //        Mobile = student.Mobile,
            //        ProfileImgUrl = student.ProfileImgUrl,
            //        GenderID = student.GenderID,
            //        //Gender = student.Gender,   //this will data model in the form of an object.
            //        //Address = student.Address
            //        Gender = new DomainModels.Gender()        //coverting the data model to Domain model
            //        {
            //            Id = student.Gender.Id,
            //            Description = student.Gender.Description
            //        },
            //        Address = new DomainModels.Address()     //coverting the data model to Domain model
            //        {
            //            Id = student.Address.Id,
            //            PhysicalAddress = student.Address.PhysicalAddress,
            //            PostalAddress = student.Address.PostalAddress,
            //            StudentID = student.Address.StudentID
            //        }
            //    });
            //}
            //return Ok(modelStudents);

            //The entire above part of manual mapping can be handled by auto mapper created under Profiles and using it as below:
            return Ok(mapper.Map<List<DomainModels.Student>>(students));
            //here the students which is a DataModel will be converted to DomainModels.Student
        }
        //fetching details of a specific student.
        [HttpGet]
        [Route("[controller]/{studentId:guid}")] //name for which route this has to be executed. 
        public async Task<IActionResult> GetStudent([FromRoute] Guid studentId)
        {
            
            var student = await studentRepository.GetStudent(studentId);
            if (student != null)
            {
                return Ok(mapper.Map<DomainModels.Student>(student));
            }
            else
            {
                return NotFound();
            }
        }
        //Update values.
        [HttpPut]
        [Route("[controller]/{studentId:guid}")]
        public async Task<IActionResult> UpdateStudent([FromRoute] Guid studentId, [FromBody] DomainModels.RequestStudent studentDetails)
        {
            var updatedStudent = await studentRepository.UpdateStudentDetails(studentId, studentDetails);
            if(updatedStudent != null)
            {
                return Ok(mapper.Map<DomainModels.Student>(updatedStudent));
            }
            else
            {
                return null;
            }
        }
        //Delete a student
        [HttpDelete]
        [Route("[controller]/{studentId:guid}")]
        public async Task<IActionResult>DeleteStudent([FromRoute] Guid studentId)
        {
            var student =  await this.studentRepository.DeleteAStudent(studentId);
            if(student != null)
            {
                return Ok(mapper.Map<DomainModels.Student>(student));
            }
            else
            {
                return NotFound();
            }
        }
    }
}
