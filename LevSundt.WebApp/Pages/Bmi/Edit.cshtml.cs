using LevSundt.WebApp.Infrastructure.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LevSundt.WebApp.Pages.Bmi;

public class EditModel : PageModel
{
    private readonly ILevSundtService _levSundtService;

    public EditModel(ILevSundtService levSundtService)
    {
        _levSundtService = levSundtService;
    }

    [BindProperty] public BmiEditViewModel BmiModel { get; set; }

    public async Task <IActionResult> OnGet(int? id)
    {
        if (id == null) return NotFound();

        var dto = await _levSundtService.Get(id.Value, User.Identity?.Name ?? string.Empty);

        BmiModel = new BmiEditViewModel
            {Height = dto.Height, Weight = dto.Weight, Id = dto.Id, Date = dto.Date, RowVersion = dto.RowVersion};

        return Page();
    }

    public IActionResult OnPost()
    {
        if (!ModelState.IsValid) return Page();

        // _command.Edit(new BmiEditRequestDto{Height = BmiModel.Height, Weight = BmiModel.Weight, Id = BmiModel.Id, Date = BmiModel.Date, RowVersion = BmiModel.RowVersion, UserId = User.Identity?.Name ?? String.Empty});

        return RedirectToPage("./Index");
    }
}