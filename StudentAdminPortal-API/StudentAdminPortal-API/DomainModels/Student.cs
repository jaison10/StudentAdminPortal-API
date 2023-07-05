using System.Diagnostics.CodeAnalysis;

namespace StudentAdminPortal_API.DomainModels
{
    public class Student
    {
        public Guid Id { get; set; }
        public string firstname { get; set; }
        public string? lastname { get; set; }
        public DateTime DOB { get; set; }
        public string? Email { get; set; }
        public long? Mobile { get; set; }
        public string? ProfileImgUrl { get; set; }

        public Guid GenderID { get; set; }
        public Gender Gender { get; set; }
        public Address Address { get; set; }
    }
}
