using Moto.Domain.Dtos.Request;
using Moto.Domain.Entities;

namespace Moto.Application.Abstractions
{
    public interface IBikeServices
    {
        public Task<BikeEntity> CreateAsync(CreateBikeRequest request);
        public Task DeleteAsync(Guid bikeId);
        public Task<List<BikeEntity>> ListAsync(string plate);
        public Task<BikeEntity> UpdateAsync(Guid bikeId, string plate);
    }
}
