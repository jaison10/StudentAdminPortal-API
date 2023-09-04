using Microsoft.AspNetCore.Mvc;
using DomainModels = StudentAdminPortal_API.DomainModels;
using StudentAdminPortal_API.Repositories;
using System.Net.NetworkInformation;
using AutoMapper;
using StudentAdminPortal_API.Models;

namespace StudentAdminPortal_API.Controllers
{
    [ApiController]
    public class StudentController : Controller
    {
        private readonly IStudentRepository studentRepository;
        private readonly IMapper mapper;
        private readonly IImageRepository imageRepository;

        public StudentController(IStudentRepository studentRepository, IMapper mapper, IImageRepository imageRepository)
        {
            this.studentRepository = studentRepository;
            this.mapper = mapper;
            this.imageRepository = imageRepository;
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
        [Route("[controller]/{studentId:guid}"), ActionName("GetStudent")] //name for which route this has to be executed. 
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
        //Create a new student
        [HttpPost]
        [Route("[controller]")]
        public async Task<IActionResult> CreateStudent([FromBody] DomainModels.NewStudentData createStudentDetails)
        {
            var createdstudent = await studentRepository.CreateNewStudent(mapper.Map<Student>(createStudentDetails));
            //return Ok(mapper.Map<DomainModels.Student>(createdstudent));
            return CreatedAtAction
                (nameof(GetStudent),
                new { studentId = createdstudent.Id },
                mapper.Map<DomainModels.Student>(createdstudent));
        }
        [HttpPost]
        [Route("[controller]/{studentId:guid}/upload-profile")]
        public async Task<IActionResult> UploadProfile([FromRoute] Guid studentId, IFormFile file )
        {
            var validExtensions = new List<String>
            {
                "jpg", "png", "jpeg"
            };

            if (file == null || file.Length == 0)
            {
                return NotFound();
            }
            else if(validExtensions.Contains(Path.GetExtension(file.FileName)) == false)
            {
                return BadRequest("This is not a valid image format.");
            }

            //getting the extension of the filename given and appending with a GUID
            var fileName = Guid.NewGuid() + Path.GetExtension(file.FileName);

            fileName = await imageRepository.UploadImage(file, fileName);
            //if( await studentRepository.UploadImageURL(studentId, fileName))
            //{
            //    return Ok(fileName);

            //}
            //else
            //{
            //    return StatusCode(StatusCodes.Status500InternalServerError, "Error occured while uploading image");
            //}
            var studentDet = await studentRepository.UploadImageURL(studentId, fileName);
            return Ok(mapper.Map<DomainModels.Student>(studentDet));
        }
    }
}
