using System;
using System.Collections.Generic;
using AdoptionCenter.DataAccess.EF.Models;
using Microsoft.EntityFrameworkCore;

namespace AdoptionCenter.DataAccess.EF.Context;

public partial class AdoptionWebsiteContext : DbContext
{
    public AdoptionWebsiteContext()
    {
    }

    public AdoptionWebsiteContext(DbContextOptions<AdoptionWebsiteContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Candidate> Candidates { get; set; }

    public virtual DbSet<Pet> Pets { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-7RABAB9\\SQLEXPRESS;Database=AdoptionWebsite;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Candidate>(entity =>
        {
            entity.ToTable("Candidate");

            entity.Property(e => e.CandidateId).HasColumnName("CandidateID");
            entity.Property(e => e.CandidateEmail)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CandidateJob)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CandidateLastName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CandidateName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CandidatePhoneNumber)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Pet>(entity =>
        {
            entity.Property(e => e.PetId).HasColumnName("PetID");
            entity.Property(e => e.PetBreed)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PetDesc)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PetName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
