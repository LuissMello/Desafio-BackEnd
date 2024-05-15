using Moto.Domain.Entities;

namespace Moto.Domain.Abstractions
{
    public interface IBaseRepository<TEntity> where TEntity : BaseEntity, new()
    {
        Task AddAsync(TEntity entity);
        void Delete(Guid id);
        void Delete(TEntity entity);
        Task<bool> ExistsAsync(Guid id);
        Task<List<TEntity>> GetAllAsync();
        Task<TEntity?> GetByIdAsync(Guid id);
        void Update(TEntity entity);
    }
}