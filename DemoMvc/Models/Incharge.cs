using System.ComponentModel.DataAnnotations.Schema;

namespace DemoMvc.Models
{
    public class Incharge
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int InchargeId { get; set; }

        public string? InchargeName { get; set; }

        public int DepartmentId { get; set; }
    }
}