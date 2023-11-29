using System.ComponentModel.DataAnnotations;
using Application.DataAccess.Contracts;
using Application.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Application.Pages;

public class IndexModel : PageModel
{
    private readonly ISectorRepository _sectorRepository;
    private readonly ISessionDataRepository _sessionDataRepository;

    [BindProperty]
    [Required(ErrorMessage = "You must specify your name.")]
    public string Name { get; set; } = string.Empty;
    
    [BindProperty]
    public List<string> SelectedSectors { get; set; } = new ();

    [BindProperty]
    [Range(typeof(bool), "true", "true", ErrorMessage = "You must agree with the terms.")]
    public bool Consent { get; set; }
    
    public IEnumerable<Sector> Sectors { get; set; } = new List<Sector>();

    public IndexModel(ISectorRepository sectorRepository, ISessionDataRepository sessionDataRepository)
    {
        _sectorRepository = sectorRepository;
        _sessionDataRepository = sessionDataRepository;
    }

    public async Task OnGet()
    {
       Sectors = await _sectorRepository.GetAllNestedAsync();
    }
    
    public async Task<IActionResult> OnPostAsync()
    {
        if (SelectedSectors.Count <= 0)
        {
            ModelState.AddModelError(nameof(SelectedSectors), "You must select at least one sector.");
        }
        
        Sectors = await _sectorRepository.GetAllNestedAsync();
        
        if (!ModelState.IsValid)
        {
            Sectors = await _sectorRepository.GetAllNestedAsync();
            return Page();
        }

        var allSectors = await _sectorRepository.GetAllAsync();

        var sessionData = new SessionData()
        {
            SessionId = HttpContext.Session.Id,
            Name = Name,
            Consent = Consent,
            Sectors = allSectors.Where(item => SelectedSectors.Contains(item.Code.ToString())).ToList()
        };

        await _sessionDataRepository.AddOrUpdateAsync(sessionData);

        return Page();
    }
}