using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StudentAdminPortal_API.Repositories;

namespace StudentAdminPortal_API.Controllers
{
    [ApiController]
    public class GenderController : Controller
    {
        private readonly IMapper mapper;
        private readonly IStudentRepository studentRepository;

        public GenderController(IMapper mapper, IStudentRepository studentRepository)
        {
            this.mapper = mapper;
            this.studentRepository = studentRepository;
        }

        [HttpGet]
        [Route("[controller]")]
        public async Task<IActionResult> GetAllGenders()
        {
            var genders = await studentRepository.GetAllGenders();
            if (genders == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<List<DomainModels.Gender>>(genders));
        }
    }
}
