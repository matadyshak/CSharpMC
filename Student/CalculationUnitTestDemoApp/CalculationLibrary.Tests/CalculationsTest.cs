namespace CalculationLibrary.Test
{
    public class CalculationsTest
    {
        [Theory]
        [InlineData(62.0d, 62.0d, 124.0d)]
        [InlineData(-1.5d, 1.5d, 0.0d)]
        [InlineData(65536.0d, -65536.0d, 0.0d)]
        public void AddShouldReturnExpectedValue(double x, double y, double expected)
        {
            // Arrange
            Calculations math = new Calculations();
            // Act
            double actual = math.Add(x, y);
            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(123.0d, 123.0d, 0.0d)]
        [InlineData(15.0d, 30.0d, -15.0d)]
        [InlineData(65536.0d, -65536.0d, 131072.0d)]
        public void SubtractShouldReturnExpectedValue(double x, double y, double expected)
        {
            // Arrange
            Calculations math = new Calculations();
            // Act
            double actual = math.Subtract(x, y);
            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(1962.0d, 4.0d, 7848.0d)]
        [InlineData(-1.0d, 1.0d, -1.0d)]
        [InlineData(0.875d, 1000.125d, 875.109375d)]
        public void MultiplyShouldReturnExpectedValue(double x, double y, double expected)
        {
            // Arrange
            Calculations math = new Calculations();
            // Act
            double actual = math.Multiply(x, y);
            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(2.0d, 3.0d, 0.66666666666666663d)]
        [InlineData(-1.0d, 1.0d, -1.0d)]
        [InlineData(100.0d, 0d, 0.0d)]
        public void DivideShouldReturnExpectedValue(double x, double y, double expected)
        {
            // Arrange
            Calculations math = new Calculations();
            // Act
            double actual = math.Divide(x, y);
            // Assert
            Assert.Equal(expected, actual);
        }
    }
}