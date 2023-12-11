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

        [Test(Description = "Тест свойства Value(провал, меньше минимума)")]
        public void ValuePropertyFailureLess()
        {
            // Arrange
            var parameter = new Parameter(10, 100);
            var value = 5;
            var excpectedMessage =
                $"Параметр должен быть в диапазоне {parameter.MinValue}-{parameter.MaxValue}.\n";

            // Assert & Act
            var exception = Assert.Throws<ArgumentException>(
                 () => parameter.Value = value);
            Assert.AreEqual(excpectedMessage, exception.Message);
        }

        [Test(Description = "Тест свойства Value(провал, больше максимума)")]
        public void ValuePropertyFailureMore()
        {
            // Arrange
            var parameter = new Parameter(10, 100);
            var value = 105;
            var excpectedMessage =
                $"Параметр должен быть в диапазоне {parameter.MinValue}-{parameter.MaxValue}.\n";

            // Assert & Act
            var exception = Assert.Throws<ArgumentException>(
                () => parameter.Value = value);
            Assert.AreEqual(excpectedMessage, exception.Message);
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
