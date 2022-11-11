using LevSundt.WebApp.Infrastructure.Contract;
using LevSundt.WebApp.Infrastructure.Contract.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LevSundt.WebApp.Pages.Bmi;

public class CreateModel : PageModel
{
    private readonly ILevSundtService _levSundtService;

    public CreateModel(ILevSundtService levSundtService)
    {
        _levSundtService = levSundtService;
    }

    [BindProperty] public BmiCreateViewModel BmiModel { get; set; } = new();

    public void OnGet()
    {
    }

    public async Task<IActionResult> OnPost()
    {
        if (!ModelState.IsValid || !BmiModel.Height.HasValue || !BmiModel.Weight.HasValue) return Page();

        var dto = new BmiCreateRequestDto
        {
            Height = BmiModel.Height.Value, Weight = BmiModel.Weight.Value, UserId = User.Identity?.Name ?? string.Empty
        };

        try
        {
            await _levSundtService.Create(dto);
        }
        catch (Exception e)
        {
            ModelState.AddModelError(string.Empty, e.Message);
            return Page();
        }
        

        return new RedirectToPageResult("/Bmi/Index");
    }
}