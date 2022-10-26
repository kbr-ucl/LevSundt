namespace LevSundt.WebApp.Infrastructure.Contract.Dto;

public class BmiEditRequestDto
{
    public double Height { get; set;}
    public double Weight { get; set;}
    public int Id { get; set;}
    public DateTime Date { get; set; }
    public byte[] RowVersion { get; set; }
    public string UserId { get; set; }
}