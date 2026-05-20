using CreativeCenterCRM.Models;
using Microsoft.EntityFrameworkCore;

namespace CreativeCenterCRM.Data
{
    public class AppDbContext : DbContext 
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<ScheduleMember> ScheduleMembers => Set<ScheduleMember>();
        public DbSet<Club> Clubs => Set<Club>();
        public DbSet<Member> Members => Set<Member>();
        public DbSet<ScheduleItem> Schedules => Set<ScheduleItem>();
        public DbSet<Payment> Payments => Set<Payment>();
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Member>()
                .HasOne(m => m.Club)
                .WithMany(c => c.Members)
                .HasForeignKey(m => m.ClubId);

            modelBuilder.Entity<ScheduleItem>()
                .HasOne(s => s.Club)
                .WithMany()
                .HasForeignKey(s => s.ClubId);

            modelBuilder.Entity<Payment>()
                .HasOne(p => p.Member)
                .WithMany() 
                .HasForeignKey(p => p.MemberId);

            modelBuilder.Entity<ScheduleMember>()
                .HasOne(sm => sm.Schedule)
                .WithMany()
                .HasForeignKey(sm => sm.ScheduleId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ScheduleMember>()
                .HasOne(sm => sm.Member)
                .WithMany()
                .HasForeignKey(sm => sm.MemberId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}