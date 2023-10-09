using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TagSampleStudentApi.Models;

public partial class TagSampleDbContext : DbContext
{
    public TagSampleDbContext()
    {
    }

    public TagSampleDbContext(DbContextOptions<TagSampleDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<StudentOriginal> StudentOriginals { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=DESKTOP-MA6EI24\\SQLEXPRESS;Database=TagSampleDb;Trusted_Connection=true;TrustServerCertificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<StudentOriginal>(entity =>
        {
            entity.HasKey(e => e.StudentId);

            entity.ToTable("Student-original");

            entity.Property(e => e.StudentId)
                .HasMaxLength(50)
                .HasColumnName("Student_ID");
            entity.Property(e => e.Class).HasMaxLength(50);
            entity.Property(e => e.Gender)
                .HasMaxLength(50)
                .HasColumnName("gender");
            entity.Property(e => e.GradeId)
                .HasColumnType("money")
                .HasColumnName("GradeID");
            entity.Property(e => e.NationalIty)
                .HasMaxLength(50)
                .HasColumnName("NationalITy");
            entity.Property(e => e.ParentschoolSatisfaction).HasMaxLength(50);
            entity.Property(e => e.PlaceofBirth).HasMaxLength(50);
            entity.Property(e => e.Raisedhands).HasColumnName("raisedhands");
            entity.Property(e => e.Relation).HasMaxLength(50);
            entity.Property(e => e.SectionId)
                .HasMaxLength(50)
                .HasColumnName("SectionID");
            entity.Property(e => e.Semester).HasMaxLength(50);
            entity.Property(e => e.StageId)
                .HasMaxLength(50)
                .HasColumnName("StageID");
            entity.Property(e => e.StudentAbsenceDays).HasMaxLength(50);
            entity.Property(e => e.StudentMarks).HasColumnName("Student_Marks");
            entity.Property(e => e.Topic).HasMaxLength(50);
            entity.Property(e => e.VisItedResources).HasColumnName("VisITedResources");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
