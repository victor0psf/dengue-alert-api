using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AlertDengueApi.Models;

namespace AlertDengueApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }
        public DbSet<DengueAlert> DengueAlerts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DengueAlert>()
                .HasIndex(da => new { da.EpidemiologicalWeek })
                .IsUnique();
        }

    }
}