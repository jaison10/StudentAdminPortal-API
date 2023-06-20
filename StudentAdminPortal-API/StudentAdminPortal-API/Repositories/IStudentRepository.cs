using StudentAdminPortal_API.Models;

namespace StudentAdminPortal_API.Repositories
{
    public interface IStudentRepository
    {
        List<Student> GetStudents();
    }
}
