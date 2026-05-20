using System.ComponentModel.DataAnnotations;

namespace CreativeCenterCRM.Models
{
    public class ScheduleMember
    {
        [Key]
        public int Id { get; set; }

        public int ScheduleId { get; set; }
        public ScheduleItem? Schedule { get; set; }

        public int MemberId { get; set; }
        public Member? Member { get; set; }

        public DateTime EnrolledAt { get; set; } = DateTime.Now;
    }
}