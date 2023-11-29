using Application.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace Application.DataAccess.Context;

public class ApplicationDbContext : DbContext
{
    public DbSet<Sector> Sectors { get; set; }

    public DbSet<SessionData> Sessions { get; set; }
    
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<SessionData>()
            .HasMany(e => e.Sectors)
            .WithMany();
    }
}