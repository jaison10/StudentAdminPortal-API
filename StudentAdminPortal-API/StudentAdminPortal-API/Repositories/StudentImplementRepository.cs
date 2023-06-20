using StudentAdminPortal_API.Data;
using StudentAdminPortal_API.Models;

namespace StudentAdminPortal_API.Repositories
{
    public class StudentImplementRepository : IStudentRepository
    {
        private readonly StudentAdminContext context;

        public StudentImplementRepository(StudentAdminContext context)
        {
            this.context = context;
        }
        public List<Student> GetStudents()
        {
            return context.Student.ToList();
        }
    }
}
