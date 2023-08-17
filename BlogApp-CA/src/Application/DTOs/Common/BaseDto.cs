namespace BlogApp_CA.Application.Common.Dtos;

public abstract class BaseAuditableDto{
    public int id{get; set;}
    public DateTime CreatedAt{get;set;}
}
