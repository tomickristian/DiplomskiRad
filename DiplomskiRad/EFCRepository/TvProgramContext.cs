using System;
using System.Collections.Generic;
using DiplomskiRad.Models;
using Microsoft.EntityFrameworkCore;

namespace DiplomskiRad.EFCRepository;

public partial class TvProgramContext : DbContext
{
    public TvProgramContext()
    {
    }

    public TvProgramContext(DbContextOptions<TvProgramContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Emisija> Emisije { get; set; }

    public virtual DbSet<TvPostaja> TvPostaje { get; set; }

    public virtual DbSet<Zanr> Zanrovi { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=ConnectionStrings:TVPROGRAM");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Emisija>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tmp_ms_x__3214EC07ED16B515");

            entity.ToTable("Emisija");

            entity.Property(e => e.DatumIvrijemePrikazivanja)
                .HasColumnType("datetime")
                .HasColumnName("DatumIVrijemePrikazivanja");
            entity.Property(e => e.Naziv).HasMaxLength(50);
            entity.Property(e => e.Opis).HasMaxLength(200);

            entity.HasOne(d => d.TvPostaja).WithMany(p => p.Emisije)
                .HasForeignKey(d => d.TvPostajaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("TvPostajaId");

            entity.HasOne(d => d.Zanr).WithMany(p => p.Emisije)
                .HasForeignKey(d => d.ZanrId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("ZanrId");
        });

        modelBuilder.Entity<TvPostaja>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tmp_ms_x__3214EC0700E72BB4");

            entity.ToTable("TvPostaja");

            entity.Property(e => e.Naziv)
                .HasMaxLength(20)
                .IsFixedLength();
        });

        modelBuilder.Entity<Zanr>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tmp_ms_x__3214EC0777AB464A");

            entity.ToTable("Zanr");

            entity.Property(e => e.Naziv)
                .HasMaxLength(20)
                .IsFixedLength();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
