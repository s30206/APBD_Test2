using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1;

public partial class RecordManiaContext : DbContext
{
    public RecordManiaContext()
    {
    }

    public RecordManiaContext(DbContextOptions<RecordManiaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Language> Languages { get; set; }

    public virtual DbSet<Record> Records { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<Task> Tasks { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Language>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Language_pk");

            entity.ToTable("Language");

            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Record>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Record_pk");

            entity.ToTable("Record");

            entity.Property(e => e.LanguageId).HasColumnName("Language_Id");
            entity.Property(e => e.StudentId).HasColumnName("Student_Id");
            entity.Property(e => e.TaskId).HasColumnName("Task_Id");

            entity.HasOne(d => d.Language).WithMany(p => p.Records)
                .HasForeignKey(d => d.LanguageId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Copy_of_Table_1_Language");

            entity.HasOne(d => d.Student).WithMany(p => p.Records)
                .HasForeignKey(d => d.StudentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Copy_of_Table_1_Student");

            entity.HasOne(d => d.Task).WithMany(p => p.Records)
                .HasForeignKey(d => d.TaskId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Copy_of_Table_1_Task");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Student_pk");

            entity.ToTable("Student");

            entity.Property(e => e.Email)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.FirstName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Task>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Task_pk");

            entity.ToTable("Task");

            entity.Property(e => e.Descrition)
                .HasMaxLength(2000)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
