using Moto.Domain.Entities;

namespace Moto.Domain.Abstractions
{
    public interface IUserRepository : IBaseRepository<UserEntity>
    {
        Task<UserEntity?> GetByCnhAsync(string cnh);
        Task<UserEntity?> GetByCnpjAsync(string cnpj);
    }
}
