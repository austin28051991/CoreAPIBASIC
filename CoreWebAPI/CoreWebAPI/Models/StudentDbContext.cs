using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CoreWebAPI.Models;

public partial class StudentDbContext : DbContext
{
    public StudentDbContext()
    {
    }

    public StudentDbContext(DbContextOptions<StudentDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Student> Students { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Student>(entity =>
        {
            entity.Property(e => e.FatherName).HasMaxLength(100);
            entity.Property(e => e.Standard).HasMaxLength(50);
            entity.Property(e => e.StudentGender)
                .HasMaxLength(50)
                .HasColumnName("Student_Gender");
            entity.Property(e => e.StudentName)
                .HasMaxLength(100)
                .HasColumnName("Student_Name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
