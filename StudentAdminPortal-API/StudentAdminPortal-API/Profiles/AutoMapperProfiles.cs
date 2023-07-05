using AutoMapper;
using StudentAdminPortal_API.Models;
using DomainModels = StudentAdminPortal_API.DomainModels;

namespace StudentAdminPortal_API.Profiles
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Student, DomainModels.Student>();
            CreateMap<Gender, DomainModels.Gender>();
            CreateMap<Address, DomainModels.Address>();
        }
    }
}
