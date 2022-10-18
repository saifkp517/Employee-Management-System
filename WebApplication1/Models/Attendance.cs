using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Attendance
    {
        [Key]
        public int attendance_id { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Name { get; set; }
        public bool Attendance_Status { get; set; }
    }
}
