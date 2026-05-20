using System.ComponentModel.DataAnnotations;

namespace CreativeCenterCRM.Models
{
    public class Club
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Название обязательно")]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;
        public string TeacherName { get; set; } = string.Empty;

        public List<Member>? Members { get; set; }
    }
}