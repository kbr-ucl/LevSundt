using LevSundt.Bmi.Domain.DomainServices;

namespace LevSundt.Bmi.Domain.Model;

public class BmiEntity
{
    private readonly IBmiDomainService _domainService;

    public BmiEntity(IBmiDomainService domainService, double height, double weight, int id)
    {
        _domainService = domainService;
        // Check pre-condition
        Height = height;
        Weight = weight;
        Id = id;
        Date = DateTime.Now;

        if (!IsValid()) throw new ArgumentException("Pre-conditions er ikke overholdt");
        if(_domainService.BmiExsistsOnDate(Date.Date)) throw new ArgumentException("Der eksisterer allerede en BMI måling for i dag");
        CalculateBmi();

    }

    public double Height { get; private set; }
    public double Weight { get; private set; }
    public double Bmi { get; private set; }
    public DateTime Date { get; }
    public int Id { get; }

    /// <summary>
    /// Acceptabel højde er [100; 250]
    ///  Acceptabel vægt et [40,0; 250,0]
    /// </summary>
    /// <returns></returns>
    protected bool IsValid()
    {
        if (Height < 100) return false;
        if (Height > 250) return false;
        if (Weight < 40) return false;
        if (Weight > 250) return false;

        return true;
    }

    protected void CalculateBmi()
    {
        Bmi = Weight / (Height/100 * Height/100);
    }

    public void Edit(double weight, double height)
    {
        Height = height;
        Weight = weight;

        if (!IsValid()) throw new ArgumentException("Pre-conditions er ikke overholdt");

        CalculateBmi();
    }
}