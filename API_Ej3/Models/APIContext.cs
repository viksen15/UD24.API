using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace API_Ej3.Models
{
    public class APIContext : DbContext
    {
        public APIContext(DbContextOptions<APIContext> options)
            : base(options)
        { }

        public DbSet<Proyecto> Proyectos { get; set; }
        public DbSet<Cientificos> Cientificos { get; set; }
        public DbSet<Asignado_A> Asignados_A { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Proyecto>()
                .HasKey(p => p.ID);
            modelBuilder.Entity<Cientificos>()
                .HasKey(p => p.DNI);
            modelBuilder.Entity<Asignado_A>()
                .HasKey(p => p.ID);
        }
    }
}
