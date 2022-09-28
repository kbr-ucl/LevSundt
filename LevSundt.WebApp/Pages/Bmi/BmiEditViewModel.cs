using System.ComponentModel.DataAnnotations;

namespace LevSundt.WebApp.Pages.Bmi
{
    public class BmiEditViewModel
    {
        [Range(100, 250)]
        public double Height { get; set; }

        [Range(40, 250)]
        public double Weight { get; set; }

        public int Id { get; set; }

        public DateTime Date { get; set;}

        public byte[] RowVersion { get; set; }
    }
}
