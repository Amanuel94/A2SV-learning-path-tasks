namespace BlogApp_CA.Domain.Common;

public abstract class BaseAuditableEntity : BaseEntity
{
    public BaseAuditableEntity()
    {
        
    }
    public DateTime CreatedAt { get; set; }
    public DateTime ModifiedAt {get; set;}

}
