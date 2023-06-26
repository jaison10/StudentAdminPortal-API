using Microsoft.EntityFrameworkCore;
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
            //return context.Student.ToList();
            return context.Student.Include(nameof(Gender)).Include(nameof(Address)).ToList();
            //the Include also returns the navigation details from other table belonging to the student.
        }
    }
}
