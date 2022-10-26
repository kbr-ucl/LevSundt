namespace LevSundt.WebApp.Infrastructure.Contracts.Dtos;

public class BmiCreateRequestDto
{
    public double Height { get; set;}
    public double Weight { get; set;}
    public string UserId { get; set; }
}