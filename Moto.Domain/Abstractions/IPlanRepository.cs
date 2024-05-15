using Moto.Domain.Entities;

namespace Moto.Domain.Abstractions
{
    public interface IPlanRepository : IBaseRepository<PlanEntity>
    {
        Task<PlanEntity?> GetByDaysAsync(int days);
    }
}
