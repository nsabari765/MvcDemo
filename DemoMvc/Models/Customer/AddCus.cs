using System.ComponentModel.DataAnnotations;

namespace DemoMvc.Models.Customer
{
    public class AddCus
    {
        [Required]
        [StringLength(15,ErrorMessage ="Name can't be more than 15 characters")]
        public string? Name { get; set; }
        [Required]
        [Phone]
        public long? PhoneNumber { get; set; }
    }
}
