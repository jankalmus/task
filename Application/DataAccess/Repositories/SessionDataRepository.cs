using Application.DataAccess.Base;
using Application.DataAccess.Context;
using Application.DataAccess.Contracts;
using Application.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace Application.DataAccess.Repositories;

public class SessionDataRepository : BaseRepository<SessionData>, ISessionDataRepository
{
    public SessionDataRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<SessionData?> GetBySessionIdAsync(string sessionId)
    {
        return await Set
            .Include(item => item.Sectors)
            .FirstOrDefaultAsync(item => item.SessionId == sessionId);
    }
}