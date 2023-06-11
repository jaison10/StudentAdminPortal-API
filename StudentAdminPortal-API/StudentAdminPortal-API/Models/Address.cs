namespace StudentAdminPortal_API.Models
{
    public class Address
    {
        public Guid Id { get; set; }
        public string PhysicalAddress { get; set; }
        public string PostalAddress { get; set; }
        //nav property
        public Guid StudentID { get; set; }
    }
}
