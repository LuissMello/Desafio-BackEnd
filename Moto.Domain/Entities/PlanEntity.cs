
namespace Moto.Domain.Entities;

public record PlanEntity : BaseEntity
{
    public int Days { get; private set; }
    public decimal Price { get; private set; }
    public decimal Fee { get; set; }

    public PlanEntity() { }

    public PlanEntity(int days, decimal price, decimal fee)
    {
        Days = days;
        Price = price;
        Fee = fee;
    }

    public void Update(int days, decimal price, decimal fee)
    {
        Days = days;
        Price = price;
        Fee = fee;
    }
}
