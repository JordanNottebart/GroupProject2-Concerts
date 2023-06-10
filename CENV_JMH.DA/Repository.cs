using CENV_JMH.DO;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace CENV_JMH.DA
{
    public class Repository : IdentityDbContext<IdentityUser>
    {
        // This represents the tables in your database
        public DbSet<Hall> Halls { get; set; }
        public DbSet<Showing> Showings { get; set; }
        public DbSet<ShowingInstance> Details { get; set; }
        public DbSet<Ticket> Tickets { get; set; }

        public Repository() { }

        public Repository(DbContextOptions<Repository> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            //  Configure the connection string for the database
            optionsBuilder.UseSqlServer(@"Data Source=.;Database=EC;Integrated Security=True;Trust Server Certificate=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region Hall Data
            // Seed initial Hall data
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
            #endregion

            #region Showing Data
            // Seed initial Showing data
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
            #endregion

            #region ShowingInstance Data
            // // Seed initial ShowingInstance data
            modelBuilder.Entity<ShowingInstance>().HasData(
                      new ShowingInstance
                      {
                          ID = 1,
                          HallID = 2,
                          ShowingID = 1,
                          Date = new DateTime(2023, 01, 12),
                          SeatsSold = 1,
                      },
                       new ShowingInstance
                       {
                           ID = 2,
                           HallID = 2,
                           ShowingID = 1,
                           Date = new DateTime(2023, 02, 13),
                           SeatsSold = 2,
                       },
                       new ShowingInstance
                       {
                           ID = 3,
                           HallID = 3,
                           ShowingID = 3,
                           Date = new DateTime(2023, 03, 14),
                           SeatsSold = 123,
                       },
                       new ShowingInstance
                       {
                           ID = 4,
                           HallID = 4,
                           ShowingID = 4,
                           Date = new DateTime(2023, 07, 19),
                           SeatsSold = 272,
                       },
                       new ShowingInstance
                       {
                           ID = 5,
                           HallID = 5,
                           ShowingID = 5,
                           Date = new DateTime(2023, 09, 25),
                           SeatsSold = 165,
                       },
                       new ShowingInstance
                       {
                           ID = 6,
                           HallID = 6,
                           ShowingID = 6,
                           Date = new DateTime(2023, 12, 29),
                           SeatsSold = 66,
                       }
                      );
            #endregion
        }
    }
}