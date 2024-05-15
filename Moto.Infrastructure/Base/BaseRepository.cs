using Microsoft.EntityFrameworkCore;
using Moto.Domain.Abstractions;
using Moto.Domain.Entities;
using Moto.Infrastructure.Context;

namespace Moto.Infrastructure.Base
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity, new()
    {
        private readonly MotoDbContext _context;
        protected DbSet<TEntity> DbSet;

        public BaseRepository(MotoDbContext context)
        {
            _context = context;
            DbSet = _context.Set<TEntity>();
        }

        public async Task AddAsync(TEntity entity)
            => await DbSet.AddAsync(entity);

        public void Delete(Guid id)
        {
            var entity = DbSet.Local.FirstOrDefault(x => x.Id == id) ?? new TEntity { Id = id };
            Delete(entity);
        }

        public void Delete(TEntity entity)
            => DbSet.Remove(entity);

        public async Task<bool> ExistsAsync(Guid id)
            => await DbSet.AnyAsync(x => x.Id == id);

        public async Task<List<TEntity>> GetAllAsync()
            => await DbSet.ToListAsync();

        public async Task<TEntity?> GetByIdAsync(Guid id)
            => await DbSet.FirstOrDefaultAsync(x => x.Id == id);

        public void Update(TEntity entity)
            => DbSet.Update(entity);
    }
}
