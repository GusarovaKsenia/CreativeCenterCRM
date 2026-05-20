using System.ComponentModel.DataAnnotations;

namespace CreativeCenterCRM.Models
{
    public class Payment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public decimal Amount { get; set; }

        [Required]
        public DateTime Date { get; set; } = DateTime.Now;

        public string Description { get; set; } = string.Empty;

        public string PaymentMethod { get; set; } = string.Empty;

        public int MemberId { get; set; }
        public Member? Member { get; set; }

        public int ClubId { get; set; }
        public Club? Club { get; set; }
    }
}