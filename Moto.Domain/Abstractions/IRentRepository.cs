using Moto.Domain.Entities;

namespace Moto.Domain.Abstractions
{
    public interface IRentRepository : IBaseRepository<RentEntity>
    {
        Task<RentEntity?> GetByBikeIdAsync(Guid bikeId);
    }
}
