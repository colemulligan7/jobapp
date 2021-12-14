using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using jobapp.Models;

namespace jobapp.Data
{
    public class jobappContext : DbContext
    {
        public jobappContext (DbContextOptions<jobappContext> options)
            : base(options)
        {
        }

        public DbSet<jobapp.Models.Order> Order { get; set; }

        public DbSet<jobapp.Models.Key> Key { get; set; }

        public DbSet<jobapp.Models.Tech> Tech { get; set; }

        public DbSet<jobapp.Models.Vehicle> Vehicle { get; set; }

        public DbSet<jobapp.Models.Pairs> Pairs { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pairs>()
                .HasIndex(p => new { p.key_id})
                .IsUnique(true);
            modelBuilder.Entity<Pairs>()
                .HasIndex(p => new { p.vehicle_id })
                .IsUnique(true);
        }
    }
}
