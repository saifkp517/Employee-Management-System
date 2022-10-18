using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Collar
    {
        [Key]
        public int collar_id { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Collar_Name { get; set; }
        public string status { get; set; }
        public string address { get; set; }
        public string name { get; set; }
    }
}
