using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DataFluentAPI.Entities;

public partial class ProjectContext : DbContext
{
    string path = File.ReadAllText("D:/.net/P1-Bhanu-Prakash/Project_0/Database/log.txt");
    public ProjectContext()
    {
    }

    public ProjectContext(DbContextOptions<ProjectContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Company> Companies { get; set; }

    public virtual DbSet<Contact> Contacts { get; set; }

    public virtual DbSet<Education> Educations { get; set; }

    public virtual DbSet<Skills> Skills { get; set; }

    public virtual DbSet<UserDetails> UserDetails { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer(path);

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Company>(entity =>
        {
            entity.HasKey(e => e.CmpId).HasName("PK__Company__F547FA7E2E5948ED");

            entity.ToTable("Company");

            entity.Property(e => e.PreviousCompany)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Technology)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.User).WithMany(p => p.Companies)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Company__UserId__6A30C649");
        });

        modelBuilder.Entity<Contact>(entity =>
        {
            entity.HasKey(e => e.ContactId).HasName("PK__Contact__5C66259B017F5C5B");

            entity.ToTable("Contact");

            entity.Property(e => e.City)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Phone)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.State)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Zipcode)
                .HasMaxLength(6)
                .IsUnicode(false);

            entity.HasOne(d => d.User).WithMany(p => p.Contacts)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Contact__UserId__6FE99F9F");
        });

        modelBuilder.Entity<Education>(entity =>
        {
            entity.HasKey(e => e.EdId).HasName("PK__Educatio__D7543F79D2A3CB8E");

            entity.ToTable("Education");

            entity.Property(e => e.Grade)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.HigherEducation)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.University)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.User).WithMany(p => p.Educations)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Education__UserI__6477ECF3");
        });

        modelBuilder.Entity<Skills>(entity =>
        {
            entity.HasKey(e => e.SkillId).HasName("PK__Skills__DFA09187BC5004DB");

            entity.Property(e => e.Skill)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Proficiency)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.User).WithMany(p => p.Skills)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Skills__UserId__6754599E");
        });

        modelBuilder.Entity<UserDetails>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__UserDeta__3213E83F92988A06");

            entity.HasIndex(e => e.Email, "UQ_Email").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Age).HasColumnName("age");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Firstname)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("firstname");
            entity.Property(e => e.Gender)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("gender");
            entity.Property(e => e.Lastname)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("lastname");
            entity.Property(e => e.Password)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("password");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
