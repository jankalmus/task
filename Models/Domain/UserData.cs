using System.ComponentModel.DataAnnotations;
using Application.DataAccess.Base;

namespace Application.Models.Domain;

public class UserData : EntityBase<Guid>
{
    [Required]
    public string Name { get; set; } = default!; 
    
    public List<Sector> Sectors { get; set; } = new List<Sector>(); 
    
    public bool Consent { get; set; }
}
