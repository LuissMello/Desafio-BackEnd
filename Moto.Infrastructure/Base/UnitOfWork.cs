using Moto.Infrastructure.Context;

namespace Moto.Infrastructure.Base;

public interface IUnitOfWork
{
    Task<bool> Commit();
}

public class UnitOfWork : IUnitOfWork
{
    private readonly MotoDbContext _context;

    public UnitOfWork(MotoDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Commit()
    {
        return await _context.SaveChangesAsync() > 0;
    }
}
