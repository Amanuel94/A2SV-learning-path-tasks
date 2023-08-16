using BlogApp_CA.Domain.Aggregates;

namespace BlogApp_CA.Domain.Entities;

public class Post: AggregateRoot{


    public PostTitle Title { get; set; } = null!;

    public PostContent Content { get; set; } = null!;

    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

    public override string ToString()
    {
        return $"Post Id: {Id}\nPost Title: {Title}\nPost Content: \n\t{Content}\nDate: {CreatedAt}";
    }
    public  string ToStringSmall()
    {
        return $"Post Title: {Title}\nPost Content: \n\t{Content}";
    }


}