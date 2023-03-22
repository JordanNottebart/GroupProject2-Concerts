using CENV_JMH.DO;
using Microsoft.EntityFrameworkCore;

namespace CENV_JMH.DA
{
    public class Repository : DbContext
    {
        public DbSet<Hall> Halls { get; set; }
        public DbSet<Showing> Showings { get; set; }
        public DbSet<ShowingDetail> Details { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer(@"Data Source=.\sqlexpress;Initial Catalog=CENV_JMH_DB;Integrated Security=True;Trust Server Certificate=True");

        }
    }
}