using System.ComponentModel.DataAnnotations;

namespace DemoMvc.Models
{
    public class Employee
    {
        public Guid Id { get; set; }

        [Required(AllowEmptyStrings = false)]
        [StringLength(15, ErrorMessage = "Name is can't be more than 15")]
        public string? Name { get; set; }
        public string? Email { get; set; }
        [Range(1000, 100000)]
        public long? Salary { get; set; }
        [Required]
        public DateTime? DateOfBirth { get; set; }
        public string? Department { get; set; }
        public long? PhoneNumber { get; set; }
        [Required(AllowEmptyStrings =false)]
        [StringLength(15)]
        public string? City { get; set; }
    }
}
