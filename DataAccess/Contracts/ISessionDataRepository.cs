using Application.Models.Domain;

namespace Application.DataAccess.Contracts;

public interface ISessionDataRepository
{
    Task<SessionData> GetDataByIdAsync(Guid sessionId);
}