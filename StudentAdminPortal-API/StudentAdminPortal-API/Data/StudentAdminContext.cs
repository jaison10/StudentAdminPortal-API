using Microsoft.EntityFrameworkCore;
using StudentAdminPortal_API.Models;

namespace StudentAdminPortal_API.Data
{
    public class StudentAdminContext : DbContext
    {
        public StudentAdminContext(DbContextOptions<StudentAdminContext> options): base(options)
        {
        }
        public DbSet<Student> Student { get; set; }
        public DbSet<Gender> Gender { get; set; }
        public DbSet<Address> Address { get; set; }

    }
}
