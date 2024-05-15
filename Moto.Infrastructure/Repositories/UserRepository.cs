using Microsoft.EntityFrameworkCore;
using Moto.Domain.Abstractions;
using Moto.Domain.Entities;
using Moto.Infrastructure.Base;
using Moto.Infrastructure.Context;

namespace Moto.Infrastructure.Repositories
{
    public class UserRepository : BaseRepository<UserEntity>, IUserRepository
    {
        public UserRepository(MotoDbContext context) : base(context)
        {
        }

        public async Task<UserEntity?> GetByCnpjAsync(string cnpj)
            => await DbSet.FirstOrDefaultAsync(e => e.Cnpj == cnpj);

        public async Task<UserEntity?> GetByCnhAsync(string cnh)
    => await DbSet.FirstOrDefaultAsync(e => e.Cnh == cnh);
    }
}
