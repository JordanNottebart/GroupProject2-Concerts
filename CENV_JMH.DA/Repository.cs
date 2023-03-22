﻿using CENV_JMH.DO;
using Microsoft.EntityFrameworkCore;

namespace CENV_JMH.DA
{
    public class Repository : DbContext
    {
        #region Properties
        public DbSet<Hall> Halls { get; set; }
        public DbSet<Showing> Showings { get; set; }
        public DbSet<ShowingDetail> Details { get; set; }

        #endregion
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
             
            optionsBuilder.UseSqlServer(@"Server=vdo2023.database.windows.net;Database= kmj;User ID=CloudSA445f05b6;Password=goodluck23!;Trusted_Connection=False;Encrypt=True;");

        }
    }
}