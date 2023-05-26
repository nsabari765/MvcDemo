namespace DemoMvc.Models
{
    public class UpdateEmployeeDetails
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public long? Salary { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? Department { get; set; }
        public long? PhoneNumber { get; set; }
        public string? City { get; set; }
    }
}
