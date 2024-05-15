using Moto.Domain.Entities;

namespace Moto.Domain.Abstractions
{
    public interface IBikeRepository : IBaseRepository<BikeEntity>
    {
        public Task<BikeEntity?> GetByPlateAsync(string plate);
    }
}
