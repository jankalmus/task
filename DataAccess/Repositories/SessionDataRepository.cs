using Application.DataAccess.Base;
using Application.DataAccess.Context;
using Application.DataAccess.Contracts;
using Application.Models.Domain;

namespace Application.DataAccess.Repositories;

public class SessionDataRepository : BaseRepository<SessionData>, ISessionDataRepository
{
    public SessionDataRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }

    public Task<SessionData> GetDataByIdAsync(Guid sessionId)
    {
        throw new NotImplementedException();
    }
}