using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Shift
    {
        [Key]
        public int shift_id { get; set; }
        [Required]
        public string Email { get; set; }
        public string Timings { get; set; }
        public string name { get; set; }
    }
}
