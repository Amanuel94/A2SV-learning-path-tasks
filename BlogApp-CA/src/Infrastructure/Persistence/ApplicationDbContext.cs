using BlogApp_CA.Domain.Common;
using BlogApp_CA.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;


namespace BlogApp_CA.Infrastructure.Persistence;
public class ApplicationDbContext : DbContext
{
    public DbSet<Post> Posts{get;set;}
    public DbSet<Comment> Comments{get;set;}
    
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
    {
        
    }

    protected ApplicationDbContext()
    {
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder){
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Comment>(entity => {
            entity.OwnsOne(t=>t.Text);
            entity.HasOne(t=>t.Post)
            .WithMany(p=>p.Comments)
            .HasForeignKey(p=>p.PostId)
            .OnDelete(DeleteBehavior.Cascade)
            .HasConstraintName("FK_Comment_to_Post");

        });

        modelBuilder.Entity<Post>(entity=>{
            entity.OwnsOne(t => t.Title);
            entity.OwnsOne(t => t.Content);
        });
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        foreach (var entry in ChangeTracker.Entries<BaseAuditableEntity>())
        {
            entry.Entity.ModifiedAt = DateTime.Now;
            if(entry.State == EntityState.Added){
                entry.Entity.CreatedAt = DateTime.Now;
            }
        }

        return base.SaveChangesAsync(cancellationToken);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){
        if(!optionsBuilder.IsConfigured)
        optionsBuilder.UseNpgsql("Host=localhost;Database=blogcadb;Username=aman;Password=passaman");

    }


}
