using Moto.Domain.Dtos.Request;
using Moto.Domain.Dtos.Response;
using Moto.Domain.Entities;

namespace Moto.Application.Abstractions
{
    public interface IRentServices
    {
        public Task<RentEntity> CreateAsync(CreateRentRequest request);
        public Task<FinishRentResponse> FinishAsync(FinishRentRequest request);
        public Task<RentEntity?> GetByBikeIdAsync(Guid bikeId);
    }
}
