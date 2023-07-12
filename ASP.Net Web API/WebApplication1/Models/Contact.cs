using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class Contact
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string? FullName { get; set; }

        public string? Email { get; set; }

        public long phone { get; set; }

        public string? Address { get; set; }
    }
}