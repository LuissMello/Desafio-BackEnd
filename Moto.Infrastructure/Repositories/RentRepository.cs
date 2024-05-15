using Microsoft.EntityFrameworkCore;
using Moto.Domain.Abstractions;
using Moto.Domain.Entities;
using Moto.Infrastructure.Base;
using Moto.Infrastructure.Context;

namespace Moto.Infrastructure.Repositories
{
    public class RentRepository : BaseRepository<RentEntity>, IRentRepository
    {
        public RentRepository(MotoDbContext context) : base(context)
        {
        }

        public async Task<RentEntity?> GetByBikeIdAsync(Guid bikeId)
           => await DbSet.FirstOrDefaultAsync(e => e.BikeId == bikeId);
    }
}
