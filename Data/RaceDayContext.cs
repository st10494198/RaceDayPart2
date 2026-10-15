using Microsoft.EntityFrameworkCore;

namespace RaceDay.Data
{
    public class RaceDayContext : DbContext
    {
        public RaceDayContext(DbContextOptions<RaceDayContext> options)
            : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Event> Events { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Enrolment> Enrolments { get; set; }

        public DbSet<Result> Results { get; set; }

      public DbSet<OrganiserProfile> OrganiserProfiles { get; set; } 

     public DbSet<ParticipantProfile> ParticipantProfiles { get; set; }


    }
}