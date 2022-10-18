using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Finance
    {
        [Key]
        public int finance_id { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public int total_amount { get; set; }
        public int cardno { get; set; }
        public int cvv { get; set; }
        public DateTime Salarycredit_Time { get; set; }
        public string validuntil { get; set; }
    }
}
