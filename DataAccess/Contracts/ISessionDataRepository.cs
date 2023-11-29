using Application.Models.Domain;

namespace Application.DataAccess.Contracts;

public interface ISessionDataRepository : IBaseRepository<SessionData>
{
    Task<SessionData?> GetBySessionIdAsync(Guid sessionId);
}