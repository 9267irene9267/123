using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MyFirstNetApi.Models;

public partial class TestContext : DbContext
{
    public TestContext()
    {
    }

    public TestContext(DbContextOptions<TestContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost;Database=Test;Trusted_Connection=True;TrustServerCertificate=True;")
     .EnableSensitiveDataLogging() // 🔍 顯示詳細查詢參數
        .LogTo(Console.WriteLine);    // 可顯示在 console

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>(entity =>
        {
            entity.ToTable("Customer");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CreateUser).HasMaxLength(50);
            entity.Property(e => e.CustomerId)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.ModifyUser).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_PRODUCT");

            entity.ToTable("Product");

            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.CreateUser).HasMaxLength(50);
            entity.Property(e => e.CustomerId).HasMaxLength(50);
            entity.Property(e => e.ModifyDate).HasColumnType("datetime");
            entity.Property(e => e.ModifyUser).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.ToTable("Student");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
