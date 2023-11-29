using Application.DataAccess.Base;
using Application.DataAccess.Context;
using Application.DataAccess.Contracts;
using Application.Models.Domain;

namespace Application.DataAccess.Repositories;

public class SectorRepository : BaseRepository<Sector>, ISectorRepository
{
    public SectorRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }

    public Task<IList<Sector>> GetAllSectors()
    {
        throw new NotImplementedException();
    }
}