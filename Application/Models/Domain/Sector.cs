using System.ComponentModel.DataAnnotations;
using Application.DataAccess.Base;

namespace Application.Models.Domain;

public class Sector : EntityBase<int>
{
    [Required]
    public string Title { get; set; } = default!; 

    [Required]
    public int Code { get; set; }

    public int? ParentSectorId { get; set; }

    public Sector? ParentSector { get; set; }

    public List<Sector> SubSectors { get; set; } = new List<Sector>(); 
    
    public Sector(string title, int code)
    {
        Title = title;
        Code = code;
    }
    
    public Sector(string title, int code, Sector? parentSector)
    {
        Title = title;
        Code = code;
        ParentSector = parentSector;
    }
    
    // EF
    public Sector() {}
}