namespace LevSundt.Bmi.Domain.Model;

public class BmiEntity
{
    public BmiEntity(double height, double weight, int id)
    {
        // Check pre-condition
        Height = height;
        Weight = weight;
        Id = id;

        if (!IsValid()) throw new ArgumentException("Pre-conditions er ikke overholdt");

        CalculateBmi();

    }

    public double Height { get; }
    public double Weight { get; }
    public double Bmi { get; private set; }
    public int Id { get; private set; }

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
}