using BloggingApp.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace BloggingApp.Models;
public class ApiDbContext:DbContext{

    

    public ApiDbContext()
    {

    }


    public ApiDbContext(DbContextOptions<ApiDbContext> options) :base(options)
    {

    }
    
    public DbSet<Post> Posts {get; set;}
    public DbSet<Comment> Comments {get;set;}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Comment>(entity =>
        {
              entity.HasOne(c => c.Post)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(x => x.PostId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Comment_Post");
        });
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){
        if(!optionsBuilder.IsConfigured)
        optionsBuilder.UseNpgsql("Host=localhost;Database=blogappdb;Username=aman;Password=passaman");

    }

}

