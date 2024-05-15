using Moto.Domain.Dtos.Request;
using Moto.Domain.Entities;

namespace Moto.Application.Abstractions
{
    public interface IPlanServices
    {
        Task CreateAsync(CreatePlanRequest request);
        Task Delete(Guid planId);
        Task<List<PlanEntity>> ListAllAsync();
        Task UpdateAsync(Guid planId, UpdatePlanRequest request);
    }
}
