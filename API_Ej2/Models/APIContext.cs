using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Ej2.Models
{
    public class APIContext : DbContext
    {
        public APIContext(DbContextOptions<APIContext> options)
            : base(options)
        { }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Videos> Videos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Videos>()
                .HasKey(p => p.ID);
            modelBuilder.Entity<Cliente>()
                .HasKey(p => p.ID);
        }
    }
}
