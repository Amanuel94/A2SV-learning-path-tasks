using System.ComponentModel.DataAnnotations.Schema;

namespace BlogApp_CA.Domain.Common;

public abstract class BaseEntity
{
    public int Id { get; set; }

}
