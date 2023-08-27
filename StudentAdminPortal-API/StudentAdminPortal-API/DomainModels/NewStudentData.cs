namespace StudentAdminPortal_API.DomainModels
{
    public class NewStudentData
    {
        public string firstname { get; set; }
        public string? lastname { get; set; }
        public DateTime DOB { get; set; }
        public string? Email { get; set; }
        public long? Mobile { get; set; }
        public Guid GenderID { get; set; }
        public string PhysicalAddress { get; set; }
        public string PostalAddress { get; set; }
    }
}
