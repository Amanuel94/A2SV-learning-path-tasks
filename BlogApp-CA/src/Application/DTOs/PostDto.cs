using BlogApp_CA.Application.Common.Dtos;
namespace BlogApp_CA.Application.Dtos;

public class PostDto:BaseAuditableDto{


    public string Title { get; set; } = null!;

    public string Content { get; set; } = null!;


}