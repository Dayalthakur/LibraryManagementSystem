using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.Models;

public partial class LibraryManagementSystemContext : DbContext
{
    public LibraryManagementSystemContext()
    {
    }

    public LibraryManagementSystemContext(DbContextOptions<LibraryManagementSystemContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Book> Books { get; set; }

    public virtual DbSet<IssuedBook> IssuedBooks { get; set; }

    public virtual DbSet<UserInfo> UserInfos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=LibraryManagementSystem;Trusted_Connection=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Book>(entity =>
        {
            entity.HasKey(e => e.BookId).HasName("PK__Books__3DE0C207D377C963");

            entity.Property(e => e.Author).HasMaxLength(50);
            entity.Property(e => e.Title).HasMaxLength(50);
        });

        modelBuilder.Entity<IssuedBook>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__IssuedBo__3214EC07A8CF7594");

            entity.Property(e => e.IssuedDate).HasColumnType("datetime");
            entity.Property(e => e.ReturnDate).HasColumnType("datetime");

            entity.HasOne(d => d.BookNavigation).WithMany(p => p.IssuedBooks)
                .HasForeignKey(d => d.Book)
                .HasConstraintName("FK__IssuedBook__Book__3A81B327");

            entity.HasOne(d => d.UserNoNavigation).WithMany(p => p.IssuedBooks)
                .HasForeignKey(d => d.UserNo)
                .HasConstraintName("FK__IssuedBoo__UserN__3B75D760");
        });

        modelBuilder.Entity<UserInfo>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__UserInfo__1788CC4C669BD881");

            entity.ToTable("UserInfo");

            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.Password).HasMaxLength(50);
            entity.Property(e => e.Username).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
