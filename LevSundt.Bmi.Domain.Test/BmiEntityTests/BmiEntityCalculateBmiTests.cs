using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LevSundt.Bmi.Domain.Model;

namespace LevSundt.Bmi.Domain.Test.BmiEntityTests
{
    public class BmiEntityCalculateBmiTests
    {

        [Theory]
        [InlineData(200, 100, 25)]
        [InlineData(190, 90, 24.9)]
        public void Given_Hight_And_Weight__The_Bmi_Is_Calculatet_Correct(double height, double wight, double exptected)
        {
            // Arrange
            var sut = new BmiEntityTest(height, wight);
            
            // Act
            sut.CalculateBmi();

            // Assert
            Assert.Equal(exptected, Math.Round(sut.Bmi,1));
        }



        public class BmiEntityTest : BmiEntity
        {
            public BmiEntityTest(double height, double weight) : base(height, weight)
            {
            }

            public new void CalculateBmi()
            {
                base.CalculateBmi();
            }
        }
    }


}
