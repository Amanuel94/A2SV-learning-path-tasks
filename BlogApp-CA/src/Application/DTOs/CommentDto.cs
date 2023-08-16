using BlogApp_CA.Application.Common.Dtos;
namespace BlogApp_CA.Application.Dtos;
public class CommentDto: BaseAuditableDto{


    public int PostId { get; set; }

    public string Text { get; set; } = null!;

}