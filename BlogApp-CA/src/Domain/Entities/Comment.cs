namespace BlogApp_CA.Domain.Entities;

public class Comment: BaseAuditableEntity{


    public int PostId { get; set; }

    public string Text { get; set; } = null!;

    public virtual required Post Post { get; set; }

    public override string ToString()
    {
        return $"Comment Id: {Id}\nPost Id: {PostId}\nText: \n\t{Text}\nDate: {CreatedAt}";
    }
    public string ToStringSmall()
    {
        return $"Comment Id: {Id}\n\tText: \n\t\t{Text}";
    }


}