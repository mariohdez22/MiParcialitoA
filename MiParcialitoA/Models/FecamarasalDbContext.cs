using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MiParcialitoA.Models;

public partial class FecamarasalDbContext : DbContext
{
    public FecamarasalDbContext()
    {
    }

    public FecamarasalDbContext(DbContextOptions<FecamarasalDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Departamento> Departamentos { get; set; }

    public virtual DbSet<Municipio> Municipios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("SQL_Latin1_General_CP1_CI_AS");

        modelBuilder.Entity<Departamento>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.DepaId)
                .HasMaxLength(255)
                .HasColumnName("depa_id");
            entity.Property(e => e.DepaNombre)
                .HasMaxLength(255)
                .HasColumnName("depa_nombre");
        });

        modelBuilder.Entity<Municipio>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.DepaId)
                .HasMaxLength(255)
                .HasColumnName("depa_id");
            entity.Property(e => e.MuniId)
                .HasMaxLength(255)
                .HasColumnName("muni_id");
            entity.Property(e => e.MuniNombre)
                .HasMaxLength(255)
                .HasColumnName("muni_nombre");
            entity.Property(e => e.MunidepaId).HasColumnName("munidepa_id");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
