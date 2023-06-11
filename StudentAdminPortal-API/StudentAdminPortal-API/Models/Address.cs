using System.Diagnostics.CodeAnalysis;

namespace StudentAdminPortal_API.Models
{
    public class Address
    {
        public Guid Id { get; set; }
        [AllowNull]
        public string PhysicalAddress { get; set; }
        [AllowNull]
        public string PostalAddress { get; set; }
        //nav property
        public Guid StudentID { get; set; }
    }
}
