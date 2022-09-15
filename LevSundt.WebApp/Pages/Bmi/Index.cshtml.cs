using LevSundt.Bmi.Application.Queries;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LevSundt.WebApp.Pages.Bmi;

public class IndexModel : PageModel
{
    private readonly IBmiGetAllQuery _bmiGetAllQuery;

    public IndexModel(IBmiGetAllQuery bmiGetAllQuery)
    {
        _bmiGetAllQuery = bmiGetAllQuery;
    }

    [BindProperty] public List<BmiIndexViewModel> IndexViewModel { get; set; } = new();

    public void OnGet()
    {
        var businessModel = _bmiGetAllQuery.GetAll();

        //foreach (var dto in businessModel)
        //{
        //    IndexViewModel.Add(new BmiIndexViewModel{Bmi = dto.Bmi, Weight = dto.Weight, Height = dto.Height, Id = dto.Id});
        //}

        businessModel.ToList().ForEach(dto => IndexViewModel.Add(new BmiIndexViewModel{Bmi = dto.Bmi, Weight = dto.Weight, Height = dto.Height, Id = dto.Id}));

    }
}