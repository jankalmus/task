using Application.DataAccess.Context;
using Microsoft.EntityFrameworkCore;

namespace Application.DataAccess.Base;

public abstract class BaseRepository<T> where T : BaseEntity
{
    private readonly ApplicationDbContext DbContext;

    protected DbSet<T> Set => DbContext.Set<T>();

    protected BaseRepository(ApplicationDbContext dbContext)
    {
        DbContext = dbContext;
    }

    public async Task AddOrUpdateAsync(T subject)
    {
        DbContext.Update(subject);

        await DbContext.SaveChangesAsync();
    }
}