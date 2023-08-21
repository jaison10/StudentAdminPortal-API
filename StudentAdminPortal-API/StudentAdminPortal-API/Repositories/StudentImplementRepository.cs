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
        public async Task<List<Student>> GetStudents()
        {
            //return context.Student.ToList();
            return await context.Student.Include(nameof(Gender)).Include(nameof(Address)).ToListAsync();
            //the Include also returns the navigation details from other table belonging to the student.
        }
        //get a specific student's info.
        public async Task<Student> GetStudent(Guid studentId)
        {
            return await context.Student.Include(nameof(Gender)).Include(nameof(Address))
                .FirstOrDefaultAsync(x=> x.Id == studentId);  //returns either the first found or NULL(default)
        }
        public async Task<List<Gender>> GetAllGenders()
        {
            return await context.Gender.Include(nameof(Gender)).ToListAsync();
        }

    }
}
