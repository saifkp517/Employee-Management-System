using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Registration
    {

        public int Id { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Name{ get; set; }
        public string Department{ get; set; }
        public string Group { get; set; }
        public string password { get; set; }
        public string Shift { get; set; }
        public int Age { get; set; }
        public string address { get; set; }
        public string status { get; set; }
        public DateTime Created { get; set; }
    }
}
