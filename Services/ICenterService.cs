using CreativeCenterCRM.Models;

namespace CreativeCenterCRM.Services
{
    public interface ICenterService
    {
        Task<List<Club>> GetAllClubsAsync();
        Task AddClubAsync(Club club);
        Task UpdateClubAsync(Club club);
        Task DeleteClubAsync(int id);

        Task<List<Member>> GetAllMembersAsync();
        Task AddMemberAsync(Member member);
        Task UpdateMemberAsync(Member member);
        Task DeleteMemberAsync(int id);

        Task<List<ScheduleItem>> GetScheduleAsync();
        Task AddScheduleAsync(ScheduleItem item);
        Task UpdateScheduleAsync(ScheduleItem item);
        Task DeleteScheduleAsync(int id);

        Task<List<Payment>> GetPaymentsAsync();
        Task AddPaymentAsync(Payment payment);

        Task<List<ScheduleMember>> GetScheduleMembersAsync(int scheduleId);
        Task AddScheduleMemberAsync(ScheduleMember scheduleMember);
    }
}