using Application.Models.Domain;

namespace Application.DataAccess.Contracts;

public interface ISectorRepository : IBaseRepository<Sector>
{
    Task<IList<Sector>> GetAllSectorsAsync();
}