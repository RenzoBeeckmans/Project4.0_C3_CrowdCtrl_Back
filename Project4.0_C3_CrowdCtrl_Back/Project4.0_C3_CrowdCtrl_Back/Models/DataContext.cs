using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System.Text.RegularExpressions;

namespace Project4._0_C3_CrowdCtrl_Back.Models
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
        : base(options)
        {
        }
        public DbSet<Event> Events { get; set; }
        public DbSet<EventType> EventTypes { get; set; }
        public DbSet<EventUser> EventUsers { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<GroupGuard> GroupGuards { get; set; }
        public DbSet<Guard> Guards { get; set; }
        public DbSet<Incident> Incidents { get; set; }
        public DbSet<RecordingDevice> RecordingDevices { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Zone> Zones { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Event>().ToTable("Event");
            modelBuilder.Entity<EventType>().ToTable("EventType");
            modelBuilder.Entity<EventUser>().ToTable("EventUser");
            modelBuilder.Entity<Feedback>().ToTable("Feedback");
            modelBuilder.Entity<Group>().ToTable("Group");
            modelBuilder.Entity<GroupGuard>().ToTable("GroupGuard");
            modelBuilder.Entity<Guard>().ToTable("Guard");
            modelBuilder.Entity<Incident>().ToTable("Incident");
            modelBuilder.Entity<RecordingDevice>().ToTable("RecordingDevice");
            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<Zone>().ToTable("Zone");
        }
    }
}
