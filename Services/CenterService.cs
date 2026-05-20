using CreativeCenterCRM.Data;
using CreativeCenterCRM.Models;
using Microsoft.EntityFrameworkCore;

namespace CreativeCenterCRM.Services
{
    public class CenterService : ICenterService
    {
        private readonly AppDbContext _context;

        public CenterService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Club>> GetAllClubsAsync()
        {
            return await _context.Clubs.Include(c => c.Members).ToListAsync();
        }

        public async Task AddClubAsync(Club club)
        {
            _context.Clubs.Add(club);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateClubAsync(Club club)
        {
            _context.Clubs.Update(club);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteClubAsync(int id)
        {
            var club = await _context.Clubs.FindAsync(id);
            if (club != null)
            {
                _context.Clubs.Remove(club);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Member>> GetAllMembersAsync()
        {
            return await _context.Members.Include(m => m.Club).ToListAsync();
        }

        public async Task AddMemberAsync(Member member)
        {
            _context.Members.Add(member);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateMemberAsync(Member member)
        {
            _context.Members.Update(member);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteMemberAsync(int id)
        {
            var member = await _context.Members.FindAsync(id);
            if (member != null)
            {
                _context.Members.Remove(member);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<ScheduleItem>> GetScheduleAsync()
        {
            return await _context.Schedules
                .Include(s => s.Club)
                .ToListAsync();
        }

        public async Task AddScheduleAsync(ScheduleItem item)
        {
            _context.Schedules.Add(item);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateScheduleAsync(ScheduleItem item)
        {
            _context.Schedules.Update(item);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteScheduleAsync(int id)
        {
            var schedule = await _context.Schedules.FindAsync(id);
            if (schedule != null)
            {
                _context.Schedules.Remove(schedule);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Payment>> GetPaymentsAsync()
        {
            return await _context.Payments
                .Include(p => p.Member)
                .ThenInclude(m => m!.Club)
                .Include(p => p.Club)
                .OrderByDescending(p => p.Date)
                .ToListAsync();
        }

        public async Task AddPaymentAsync(Payment payment)
        {
            _context.Payments.Add(payment);
            await _context.SaveChangesAsync();
        }
        public async Task<List<ScheduleMember>> GetScheduleMembersAsync(int scheduleId)
        {
            return await _context.ScheduleMembers
                .Include(sm => sm.Member)
                .Where(sm => sm.ScheduleId == scheduleId)
                .ToListAsync();
        }

        public async Task AddScheduleMemberAsync(ScheduleMember scheduleMember)
        {
            _context.ScheduleMembers.Add(scheduleMember);
            await _context.SaveChangesAsync();
        }
        
    }
}