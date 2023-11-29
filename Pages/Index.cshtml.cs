using System.ComponentModel.DataAnnotations;
using Application.DataAccess.Contracts;
using Application.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Application.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly ISectorRepository _sectorRepository;

    [BindProperty]
    [Required(ErrorMessage = "You must specify your name.")]
    public string Name { get; set; } = string.Empty;
    
    [BindProperty]
    public List<string> SelectedSectors { get; set; } = new ();

    [BindProperty]
    [Range(typeof(bool), "true", "true", ErrorMessage = "You must agree with the terms.")]
    public bool Consent { get; set; }
    
    public IEnumerable<Sector> Sectors { get; set; } = new List<Sector>();

    public IndexModel(ILogger<IndexModel> logger, ISectorRepository sectorRepository)
    {
        _logger = logger;
        _sectorRepository = sectorRepository;
    }

    public async Task OnGet()
    {
       Sectors = await _sectorRepository.GetAllSectorsAsync();
    }
    
    public async Task<IActionResult> OnPostAsync()
    {
        if (SelectedSectors.Count <= 0)
        {
            ModelState.AddModelError(nameof(SelectedSectors), "You must select at least one sector.");
        }
        
        if (!ModelState.IsValid)
        {
            Sectors = await _sectorRepository.GetAllSectorsAsync();
            return Page();
        }

        return RedirectToPage("./Index");
    }
}