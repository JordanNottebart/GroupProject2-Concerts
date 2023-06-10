using CENV_JMH.DO;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace CENV_JMH.DA
{
    public class Repository : IdentityDbContext<IdentityUser>
    {
        #region Properties
        public DbSet<Hall> Halls { get; set; }
        public DbSet<Showing> Showings { get; set; }
        public DbSet<ShowingInstance> Details { get; set; }
        public DbSet<Ticket> Tickets { get; set; }

        public Repository() { }

        public Repository(DbContextOptions<Repository> options) : base(options) { }

        #endregion
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer(@"Data Source=.;Database=EC;Integrated Security=True;Trust Server Certificate=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Hall>().HasData(
                   new Hall
                   { HallID = 1, Name = "The Avenue", Number = 1, MaxNumberOfPlaces = 12 },
                   new Hall
                   { HallID = 2, Name = "Atlantis", Number = 2, MaxNumberOfPlaces = 123 },
                   new Hall
                   { HallID = 3, Name = "Lotus Lakes", Number = 3, MaxNumberOfPlaces = 99 },
                   new Hall
                   { HallID = 4, Name = "The Arctic", Number = 4, MaxNumberOfPlaces = 134 }
                   );
        }

    }
}