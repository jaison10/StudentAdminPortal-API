using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace StudentAdminPortal_API.Models
{
    public class Student
    {
        [Key]
        public  Guid Id { get; set; }
        public string firstname { get; set; }    
        public string? lastname { get; set; } 
        public DateTime DOB { get; set; }  
        public string? Email { get; set; }
        public long? Mobile { get; set; }
        [AllowNull]
        public string? ProfileImgUrl { get; set; }
        
        public Guid GenderID { get; set; }
        //Navigation Properties
        public Gender Gender { get; set; }
        public Address Address { get; set;}

    }
}
