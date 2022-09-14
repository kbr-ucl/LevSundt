using LevSundt.Bmi.Domain.Model;

namespace LevSundt.Bmi.Domain.Test.BmiEntityTests;

public class BmiEntityCalculateBmiTests
{
    [Theory]
    [InlineData(200, 100, 25)]
    [InlineData(190, 90, 24.9)]
    public void Given_Hight_And_Weight__The_Bmi_Is_Calculatet_Correct(double height, double wight, double exptected)
    {
        // Arrange
        var sut = new BmiEntityTest(height, wight, 1);

        // Act
        sut.CalculateBmi();

        // Assert
        Assert.Equal(exptected, Math.Round(sut.Bmi, 1));
    }


    public class BmiEntityTest : BmiEntity
    {
        public BmiEntityTest(double height, double weight, int id) : base(height, weight, id)
        {
        }

        public new void CalculateBmi()
        {
            base.CalculateBmi();
        }
    }
}