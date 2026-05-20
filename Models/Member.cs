using System.ComponentModel.DataAnnotations;

namespace CreativeCenterCRM.Models
{
    public class Member
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string LastName { get; set; } = string.Empty;

        public string Phone { get; set; } = string.Empty;
        public int Age { get; set; }

        public string? Comment { get; set; }

        public int ClubId { get; set; }
        public Club? Club { get; set; }
    }
}