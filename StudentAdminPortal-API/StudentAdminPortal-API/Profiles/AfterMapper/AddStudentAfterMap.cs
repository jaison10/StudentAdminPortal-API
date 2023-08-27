using AutoMapper;
using StudentAdminPortal_API.Models;
using DomainModels = StudentAdminPortal_API.DomainModels;

namespace StudentAdminPortal_API.Profiles.AfterMapper
{
    public class AddStudentAfterMap : IMappingAction<DomainModels.NewStudentData, Student>
    {
        public void Process(DomainModels.NewStudentData source, Student destination, ResolutionContext context)
        {
            destination.Id = Guid.NewGuid();
            destination.Address = new Address
            {
                Id = Guid.NewGuid(),
                PhysicalAddress = source.PhysicalAddress,
                PostalAddress = source.PostalAddress
            };
        }
    }
}
