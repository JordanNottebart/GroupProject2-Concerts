using CENV_JMH.DO;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

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
            optionsBuilder.UseSqlServer(@"Data Source=.\sqlexpress;Initial Catalog=CENV_JHM;Integrated Security=True;Trust Server Certificate=True");
        }
    }
}