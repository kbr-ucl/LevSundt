using System.ComponentModel.DataAnnotations;

namespace LevSundt.WebApp.Pages.Bmi
{
    public class BmiCreateViewModel
    {
        [Range(100, 250)]
        public double? Height { get; set; }

        [Range(40, 250)]
        public double? Weight { get; set; }
    }
}
