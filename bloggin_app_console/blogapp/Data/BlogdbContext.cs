using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using bloggin_app_console.Models;
namespace bloggin_app_console.Models;

public partial class BlogdbContext : DbContext
{
    public BlogdbContext()
    {
    }

    public BlogdbContext(DbContextOptions<BlogdbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Comment> Comments { get; set; }

    public virtual DbSet<Post> Posts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){
        if(!optionsBuilder.IsConfigured)
        optionsBuilder.UseNpgsql("Host=localhost;Database=blogdb;Username=aman;Password=passaman");

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Comment>(entity =>
        {
            entity.ToTable("Comment");

            entity.HasIndex(e => e.PostId, "IX_Comment_PostId");

            entity.HasOne(d => d.Post).WithMany(p => p.Comments).HasForeignKey(d => d.PostId);
            entity.Property(p => p.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");
        });

        modelBuilder.Entity<Post>(entity =>
        {
            entity.ToTable("Post");
            entity.Property(p => p.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
