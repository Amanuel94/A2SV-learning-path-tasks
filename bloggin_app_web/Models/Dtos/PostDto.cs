namespace BloggingApp.Models;
public class PostDto{
    public int PostId { get; set; }

    public string Title { get; set; } = null!;

    public string Content { get; set; } = null!;
    public DateTime CreatedAt {get; set;}
}