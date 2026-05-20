namespace CreativeCenterCRM.Models
{
    public class ScheduleItem
    {
        public int Id { get; set; }
        public string DayOfWeek { get; set; } = string.Empty;
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public int ClubId { get; set; }
        public Club? Club { get; set; }
        public string Room { get; set; } = string.Empty;

        public int MaxSeats { get; set; } = 10; 
        public int CurrentSeats { get; set; } = 0; 
    }
}