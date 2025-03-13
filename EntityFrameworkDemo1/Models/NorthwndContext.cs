using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkDemo1.Models;

public partial class NorthwndContext : DbContext
{
    public NorthwndContext()
    {
    }

    public NorthwndContext(DbContextOptions<NorthwndContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Post> Posts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=LAPTOP-4G8BHPK9\\SQLEXPRESS;Initial Catalog=NORTHWND;Integrated Security=true;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Post>(entity =>
        {
            entity.HasKey(e => e.PostId).HasName("PK__Post__AA126018C3EC1EBB");

            entity.ToTable("Post");

            entity.Property(e => e.PostId).ValueGeneratedNever();
            entity.Property(e => e.Body)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("body");
            entity.Property(e => e.DatePublished).HasColumnType("datetime");
            entity.Property(e => e.Title)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
