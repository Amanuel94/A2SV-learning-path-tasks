using bloggin_app_console.controllers;
using Microsoft.EntityFrameworkCore;
using bloggin_app_console.Models;
public partial class Driver{

    public static BlogdbContext ContextGenerator(){
        var optionsBuilder = new DbContextOptionsBuilder<BlogdbContext>();
        optionsBuilder.UseNpgsql("Host=localhost;Database=blogdb;Username=aman;Password=passaman");
        BlogdbContext dbContext = new BlogdbContext(optionsBuilder.Options);
        return dbContext;
    }
    public static PostManager CreatePostManager(){
        
        return new PostManager(ContextGenerator());
    }
    
    public static CommentManager CreateCommentManager(){
        
        return new CommentManager(ContextGenerator());
    }
}