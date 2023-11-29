using Application.DataAccess.Base;
using Application.DataAccess.Context;
using Application.DataAccess.Contracts;
using Application.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace Application.DataAccess.Repositories;

public class SectorRepository : BaseRepository<Sector>, ISectorRepository
{
    public SectorRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<IList<Sector>> GetAllSectorsAsync()
    {
        var sectors = await Set.ToListAsync(); 
        
        sectors.ForEach(item => item.SubSectors = sectors.Where(sub => sub.ParentSectorId == item.Id).ToList());

        return sectors.Where(item => item.ParentSectorId == null).ToList();
    }
}