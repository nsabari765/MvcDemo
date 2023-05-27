using System.ComponentModel.DataAnnotations;

namespace DemoMvc.Models
{
    public class AddEmployeeModel
    {
        [Required]
        [StringLength(15, ErrorMessage = "Name is can't be more than 15")]
        public string? Name { get; set; }
        [Required]
        public string? Email { get; set; }
        public long? Salary { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? Department { get; set; }
        public long? PhoneNumber { get; set; }
        [Required]
        public string? City { get; set; }
    }
}
