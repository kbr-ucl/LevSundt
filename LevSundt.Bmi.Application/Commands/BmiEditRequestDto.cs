namespace LevSundt.Bmi.Application.Commands;

public class BmiEditRequestDto
{
    public double Height { get; set;}
    public double Weight { get; set;}
    public int Id { get; set;}
    public DateTime Date { get; set; }
}