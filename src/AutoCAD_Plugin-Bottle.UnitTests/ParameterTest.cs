namespace AutoCAD_Plugin_Bottle.UnitTests
{
    [TestFixture]
    public class ParameterTest
    {
        [Test(Description = "Тест свойства MinValue")]
        public void MinValueProperty()
        {
            // Arrange
            var parameter = new Parameter(10, 100);
            var expected = 20;

            // Act
            parameter.MinValue = expected;
            var actual = parameter.MinValue;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test(Description = "Тест свойства MaxValue")]
        public void MaxValueProperty()
        {
            // Arrange
            var parameter = new Parameter(10, 100);
            var expected = 120;

            // Act
            parameter.MaxValue = expected;
            var actual = parameter.MaxValue;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test(Description = "Тест свойства Value(успех)")]
        public void ValuePropertySuccess()
        {
            // Arrange
            var parameter = new Parameter(10, 100);
            var expected = 80;

            // Act
            parameter.Value = expected;
            var actual = parameter.Value;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test(Description = 
            "Тест свойства Value (провал, значение вне допустимого диапазона)")]
        [TestCase(10, 100, 5)]
        [TestCase(10, 100, 105)]
        public void ValuePropertyFailureRange(double min, double max, double value)
        {
            // Arrange
            var parameter = new Parameter(min, max);
            var expectedMessage =
                $"Параметр должен быть в диапазоне {parameter.MinValue}-{parameter.MaxValue}.\n";

            // Assert & Act
            var exception = Assert.Throws<ArgumentException>(
                 () => parameter.Value = value);
            Assert.AreEqual(expectedMessage, exception.Message);
        }

        [Test(Description =
            "Тест свойства Value (провал, максимальное значение меньше минимального)")]
        public void ValuePropertyFailureMinMax()
        {
            // Arrange
            var parameter = new Parameter(100, 10);
            var value = 15;
            var expectedMessage =
                $"Минимальное значение должно быть меньше максимального.";

            // Assert & Act
            var exception = Assert.Throws<ArgumentException>(
                () => parameter.Value = value
                );
            Assert.AreEqual(expectedMessage, exception.Message);
        }

        [Test(Description = "Тест метода ReturnToDefaultValue")]
        public void ReturnToDefaultValueTest()
        {
            // Arrange
            var parameter = new Parameter(10, 100);
            parameter.Value = 50;
            var expected = 10;

            // Act
            parameter.ReturnToDefaultValue();
            var actual = parameter.Value;

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
