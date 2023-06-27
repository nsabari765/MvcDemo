using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DemoMvc.Models
{
    public class Incharge
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int InchargeId { get; set; }

        public int SerialNumber { get; set; }
        public string? InchargeName { get; set; }

        public int DepartmentId { get; set; }
    }
}