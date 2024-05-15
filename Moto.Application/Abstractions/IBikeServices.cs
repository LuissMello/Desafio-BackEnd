using Moto.Domain.Dtos.Request;
using Moto.Domain.Entities;

namespace Moto.Application.Abstractions
{
    public interface IBikeServices
    {
        public Task CreateAsync(CreateBikeRequest request);
        public Task DeleteAsync(Guid bikeId);
        public Task<List<BikeEntity>> ListAsync(string plate);
        public Task UpdateAsync(Guid bikeId, string plate);
    }
}
