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
                   { HallID = 4, Name = "The Arctic", Number = 4, MaxNumberOfPlaces = 134 },
                   new Hall
                   { HallID = 5, Name = "Sapphire Palace", Number = 5, MaxNumberOfPlaces = 111 },
                   new Hall
                   { HallID = 6, Name = "Elliot", Number = 6, MaxNumberOfPlaces = 78 }
                   );

            modelBuilder.Entity<Showing>().HasData(
                   new Showing
                   {
                       ShowingID = 1,
                       Name = "Mythical Music",
                       TicketPrice = 19.99,
                       Picture_URL = ""
                   },
                   new Showing
                   {
                       ShowingID = 2,
                       Name = "The X Sounds",
                       TicketPrice = 199.99,
                       Picture_URL = ""
                   },
                   new Showing
                   {
                       ShowingID = 3,
                       Name = "Dsss Trackk",
                       TicketPrice = 419.99,
                       Picture_URL = ""
                   },
                   new Showing
                   {
                       ShowingID = 4,
                       Name = "Just A Voice",
                       TicketPrice = 29.99,
                       Picture_URL = ""
                   },
                   new Showing
                   {
                       ShowingID = 5,
                       Name = "Royal Plam Concert",
                       TicketPrice = 89.99,
                       Picture_URL = ""
                   },
                   new Showing
                   {
                       ShowingID = 6,
                       Name = "Original Music Mantra",
                       TicketPrice = 69.99,
                       Picture_URL = ""
                   }
                   );
        }
    }
}