using Application.Models.Domain;

namespace Application.DataAccess.Contracts;

public interface ISectorRepository
{
    Task<IList<Sector>> GetAllSectorsAsync();
}