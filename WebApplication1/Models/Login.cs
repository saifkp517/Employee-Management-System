using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Login
    {

        public int Id { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string password { get; set; }
    }
}
