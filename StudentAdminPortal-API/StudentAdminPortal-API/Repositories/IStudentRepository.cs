using DomainModels = StudentAdminPortal_API.DomainModels;
using StudentAdminPortal_API.Models;

namespace StudentAdminPortal_API.Repositories
{
    public interface IStudentRepository
    {
        Task<List<Student>> GetStudents();
        //Method declaration to fetch a specific student info.
        Task<Student> GetStudent(Guid studentId);
        Task<List<Gender>> GetAllGenders();
        Task<Student> UpdateStudentDetails(Guid studentId, DomainModels.RequestStudent requestStudentDetails);
        Task<Boolean> DeleteAStudent(Guid studentId);
    }
}
