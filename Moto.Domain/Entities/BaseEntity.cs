namespace Moto.Domain.Entities;

public abstract record BaseEntity
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }
}
