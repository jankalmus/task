using System.ComponentModel.DataAnnotations;

namespace Application.DataAccess.Base;

public abstract class EntityBase<T> : BaseEntity where T : struct
{
    [Key]
    [Required]
    public T Id { get; set; }
}

public abstract class BaseEntity
{
    
}