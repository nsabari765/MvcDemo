using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DemoMvc.Models
{
    public class HodName
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string? Name { get; set; }

        [Required(ErrorMessage = "Required Department")]
        public int? DepartmentId { get; set; }

        public string? DepartmentName { get; set; }
    }
}