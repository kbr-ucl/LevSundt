using LevSundt.Bmi.Application.Commands;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LevSundt.WebApp.Pages.Bmi
{
    public class CreateModel : PageModel
    {
        private readonly ICreateBmiCommand _createBmiCommand;

        public CreateModel(ICreateBmiCommand createBmiCommand)
        {
            _createBmiCommand = createBmiCommand;
        }

        [BindProperty]
        public BmiCreateViewModel BmiModel { get; set; } = new();

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid) return Page();

            var dto = new BmiCreateRequestDto{Height = BmiModel.Height.Value, Weight = BmiModel.Weight.Value, UserId = User.Identity?.Name ?? String.Empty};
            _createBmiCommand.Create(dto);

            return new RedirectToPageResult("/Bmi/Index");
        }
    }
}
