using Moto.Domain.Dtos.Request;
using Moto.Domain.Dtos.Response;
using Moto.Domain.Entities;

namespace Moto.Application.Abstractions
{
    public interface IPlanServices
    {
        Task<PlanEntity> CreateAsync(CreatePlanRequest request);
        Task Delete(Guid planId);
        Task<List<PlanEntity>> ListAllAsync();
        Task<PlanEntity> UpdateAsync(Guid planId, UpdatePlanRequest request);
    }
}
