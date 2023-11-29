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

    public async Task<SessionData?> GetDataByIdAsync(Guid sessionId)
    {
        return await Set.FirstOrDefaultAsync(item => item.Id == sessionId);
    }
}