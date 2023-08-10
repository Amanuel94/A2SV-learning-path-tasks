
namespace BloggingApp.Models;

public  class CommentDto
{
    public int CommentId { get; set; }

    public int PostId { get; set; }

    public string Text { get; set; } = null!;

    public DateTime CreatedAt {get; set;}
}
