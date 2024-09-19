using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace AjusteCSV.Access.Data
{
    public partial class DannteEssaContext : DbContext
    {
        public DannteEssaContext()
        {
        }

        public DannteEssaContext(DbContextOptions<DannteEssaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Ideam> Ideams { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ideam>(entity =>
            {
                entity.ToTable("ideam", "machine");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Altitude).HasColumnName("altitude");

                entity.Property(e => e.Date).HasColumnName("date");

                entity.Property(e => e.Department)
                    .HasMaxLength(255)
                    .HasColumnName("department");

                entity.Property(e => e.Frequency)
                    .HasMaxLength(20)
                    .HasColumnName("frequency");

                entity.Property(e => e.Latitude).HasColumnName("latitude");

                entity.Property(e => e.Longitude).HasColumnName("longitude");

                entity.Property(e => e.Municipality)
                    .HasMaxLength(255)
                    .HasColumnName("municipality");

                entity.Property(e => e.Parameterid)
                    .HasMaxLength(20)
                    .HasColumnName("parameterid");

                entity.Property(e => e.Precipitation).HasColumnName("precipitation");

                entity.Property(e => e.Stationcode)
                    .HasMaxLength(10)
                    .HasColumnName("stationcode");

                entity.Property(e => e.Stationname)
                    .HasMaxLength(255)
                    .HasColumnName("stationname");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
