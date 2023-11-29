using System.ComponentModel.DataAnnotations;
using Application.DataAccess.Base;

namespace Application.Models.Domain;

public class SessionData : EntityBase<int>
{
    [Required] 
    public string SessionId { get; set; } = default!;
    
    [Required]
    public string Name { get; set; } = default!; 
    
    public List<Sector> Sectors { get; set; } = new(); 
    
    public bool Consent { get; set; }
}
