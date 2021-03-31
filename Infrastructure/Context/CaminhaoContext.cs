using Domain;
using Microsoft.EntityFrameworkCore;
using System;

namespace Infrastucture
{
    public class CaminhaoContext : DbContext
    {
        public CaminhaoContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured) return;
            optionsBuilder
                .UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=CaminhaoDiogoDias;Trusted_Connection=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<CaminhaoModelo>().HasKey(t => t.id);

            modelBuilder.Entity<Caminhao>().HasKey(t => t.id);

            modelBuilder.Entity<Caminhao>().HasOne(t => t.caminhaoModelo);
        }
    }
}
