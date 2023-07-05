using StudentAdminPortal_API.Models;

namespace StudentAdminPortal_API.Repositories
{
    public interface IStudentRepository
    {
        Task<List<Student>> GetStudents();
    }
}
