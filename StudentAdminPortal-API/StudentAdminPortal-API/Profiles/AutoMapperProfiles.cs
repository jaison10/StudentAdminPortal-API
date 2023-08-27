using AutoMapper;
using StudentAdminPortal_API.Models;
using StudentAdminPortal_API.Profiles.AfterMapper;
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
            //CreateMap<DomainModels.RequestStudent, DomainModels.Student>();
            CreateMap<DomainModels.NewStudentData, Student>().AfterMap<AddStudentAfterMap>();
        }
    }
}
