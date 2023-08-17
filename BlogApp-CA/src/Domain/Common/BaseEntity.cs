using System.ComponentModel.DataAnnotations.Schema;

namespace BlogApp_CA.Domain.Common;

public abstract class BaseEntity
{
    public BaseEntity()
    {
        
    }
    public int Id { get; set; }

    public List<BaseEvent> DomainEvents = new();

    public void AddDomainEvent(BaseEvent _event){
        DomainEvents.Add(_event);
    }


}
