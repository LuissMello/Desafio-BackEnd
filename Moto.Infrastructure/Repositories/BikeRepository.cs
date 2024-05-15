using Microsoft.EntityFrameworkCore;
using Moto.Domain.Abstractions;
using Moto.Domain.Entities;
using Moto.Infrastructure.Base;
using Moto.Infrastructure.Context;

namespace Moto.Infrastructure.Repositories
{
    public class BikeRepository : BaseRepository<BikeEntity>, IBikeRepository
    {
        public BikeRepository(MotoDbContext context) : base(context)
        {
        }

        public async Task<BikeEntity?> GetByPlateAsync(string plate)
            => await DbSet.FirstOrDefaultAsync(x => x.Plate == plate);
    }
}
