using LevSundt.Bmi.Domain.Model;

namespace LevSundt.Bmi.Domain.Test.BmiEntityTests;

public class BmiEntityCreateTests
{
    /// <summary>
    ///     Acceptabel højde er [100; 250]
    /// </summary>
    [Theory]
    [InlineData(200)]
    [InlineData(250)]
    [InlineData(100)]
    public void Given_Height_Is_Valid__Then_BmiEntity_Is_Created(double height)
    {
        // Arrange

        // Act
        var sut = new BmiEntity(height, 100, 1);
        // Assert
    }

    /// <summary>
    ///     Acceptabel højde er [100; 250]
    /// </summary>
    [Theory]
    [InlineData(250.01)]
    [InlineData(99.99)]
    public void Given_Height_Is_InValid__Then_ArgumentException_Is_Thrown(double height)
    {
        // Arrange

        // Act

        // Assert
        Assert.Throws<ArgumentException>(() => new BmiEntity(height, 100, 1));
    }

    /// <summary>
    ///     Acceptabel vægt et [40,0; 250,0]
    /// </summary>
    [Theory]
    [InlineData(100)]
    [InlineData(250)]
    [InlineData(40)]
    public void Given_Weight_Is_Valid__Then_BmiEntity_Is_Created(double weight)
    {
        // Arrange

        // Act
        var sut = new BmiEntity(200, weight, 1) ;
        // Assert
    }

    /// <summary>
    ///     Acceptabel vægt et [40,0; 250,0]
    /// </summary>
    [Theory]
    [InlineData(250.01)]
    [InlineData(39.99)]
    public void Given_Weight_Is_InValid__Then_ArgumentException_Is_Thrown(double weight)
    {
        // Arrange

        // Act

        // Assert
        Assert.Throws<ArgumentException>(() => new BmiEntity(200, weight, 1));
    }

    [Theory]
    [InlineData(200, 100, 25)]
    [InlineData(190, 90, 24.9)]
    public void Given_Hight_And_Weight__The_Bmi_Is_Calculatet_Correct(double height, double wight, double exptected)
    {
        // Arrange
        
        // Act
        var sut = new BmiEntity(height, wight, 1);

        // Assert
        Assert.Equal(exptected, Math.Round(sut.Bmi,1));
    }
}