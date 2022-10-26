using LevSundt.WebApp.Infrastructure.Contracts;
using LevSundt.WebApp.Infrastructure.Contracts.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LevSundt.WebApp.Pages.Bmi
{
    public class CreateModel : PageModel
    {
        private readonly ILevSundtService _levSundtService;

        public CreateModel(ILevSundtService levSundtService)
        {
            _levSundtService = levSundtService;
        }

        [BindProperty]
        public BmiCreateViewModel BmiModel { get; set; } = new();

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid) return Page();

            var dto = new BmiCreateRequestDto{Height = BmiModel.Height.Value, Weight = BmiModel.Weight.Value, UserId = User.Identity?.Name ?? String.Empty};
            await _levSundtService.Create(dto);

            return new RedirectToPageResult("/Bmi/Index");
        }
    }
}
