using challenge_lovys_repository.Entities;
using Microsoft.EntityFrameworkCore;

namespace challenge_lovys_repository.Context
{
    public class LovysContext : DbContext
    {
        public LovysContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<AvailableNextWeekEntities>().HasKey(x => x.NextWeekId);
            modelBuilder.Entity<AvailableNextWeekEntities>().HasOne(x => x.ScheduleEntitiesId);
            modelBuilder.Entity<AvailableTimesEntities>().HasKey(x => x.AvailableTimeId);
            modelBuilder.Entity<AvailableTimesEntities>().HasOne(x => x.NextWeekId);
        }
        public DbSet<ScheduleEntities> Schedules { get; set; }
        public DbSet<AvailableNextWeekEntities> AvailableNextWeeks { get; set; }
        public DbSet<AvailableTimesEntities> AvailableTimes { get; set; }
    }
}
