using Moto.Domain.Dtos.Request;
using Moto.Domain.Entities;

namespace Moto.Application.Abstractions
{
    public interface IUserServices
    {
        public Task<UserEntity?> GetByCnpjAsync(string cnpj);
        public Task<UserEntity?> GetByIdAsync(Guid userId);
        public Task<List<UserEntity>> GetAllAsync();
        public Task<UserEntity> ResisterAsync(RegisterUserRequest newUser);
    }
}
