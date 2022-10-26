using LevSundt.WebApp.Infrastructure.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LevSundt.WebApp.Pages.Coach;

public class DetailsModel : PageModel
{
    private readonly ILevSundtService _levSundtService;

    public DetailsModel(ILevSundtService levSundtService)
    {
        _levSundtService = levSundtService;
    }

    [BindProperty] public List<CoachDetailsViewModel> DetailsViewModel { get; set; } = new();
    [BindProperty] public string UserName { get; set; } = string.Empty;


    public async Task<IActionResult> OnGet(string? userId)
    {
        if (string.IsNullOrWhiteSpace(userId)) return NotFound();

        var businessModel = await _levSundtService.GetAll(userId);

        if (businessModel is null) return Page();


        businessModel.OrderBy(a => a.Date).ToList().ForEach(dto => DetailsViewModel.Add(new CoachDetailsViewModel
            {Bmi = dto.Bmi, Weight = dto.Weight, Height = dto.Height, Id = dto.Id, Date = dto.Date}));

        UserName = userId;

        return Page();
    }
}