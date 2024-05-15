using Microsoft.EntityFrameworkCore;
using Moto.Domain.Abstractions;
using Moto.Domain.Entities;
using Moto.Infrastructure.Base;
using Moto.Infrastructure.Context;

namespace Moto.Infrastructure.Repositories
{
    public class PlanRepository : BaseRepository<PlanEntity>, IPlanRepository
    {
        public PlanRepository(MotoDbContext context) : base(context)
        {
        }

        public async Task<PlanEntity?> GetByDaysAsync(int days)
            => await DbSet.FirstOrDefaultAsync(x => x.Days == days);
    }
}
