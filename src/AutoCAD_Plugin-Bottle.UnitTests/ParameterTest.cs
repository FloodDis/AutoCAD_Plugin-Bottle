namespace AutoCAD_Plugin_Bottle.UnitTests
{
    [TestFixture]
    public class ParameterTest
    {
        [Test(Description = "Тест свойства поля _maxValue")]
        public void MaxValueProperty()
        {
            // Arrange
            var expected = 100;
            var parameter = new Parameter(BottleParameterType.MainHeight);

            // Act
            parameter.MaxValue = expected;
            var actual = parameter.MaxValue;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test(Description = "Тест свойства поля _minValue")]
        public void MinValueProperty()
        {
            // Arrange
            var expected = 10;
            var parameter = new Parameter(BottleParameterType.MainHeight);

            // Act
            parameter.MinValue = expected;
            var actual = parameter.MinValue;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test(Description = "Тест свойства поля _value (успешный)")]
        public void ValuePropertySuccess()
        {
            // Arrange
            var expected = 110;
            var parameter = new Parameter(BottleParameterType.MainHeight);

            // Act
            parameter.Value = expected;
            var actual = parameter.Value;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test(Description = "Тест свойства поля _value (провальный)(меньше минимума")]
        public void ValuePropertyFailureLess()
        {
            // Arrange
            var expected = 1;
            var parameter = new Parameter(BottleParameterType.MainHeight);
            parameter.MinValue = 10;
            parameter.MaxValue = 100;

            // Assert
            Assert.Throws<ArgumentException>(
                // Act
                () => parameter.Value = expected
                );
        }

        [Test(Description = "Тест свойства поля _value (провальный)(больше максимума")]
        public void ValuePropertyFailureMore()
        {
            // Arrange
            var expected = 150;
            var parameter = new Parameter(BottleParameterType.MainHeight);
            parameter.MinValue = 10;
            parameter.MaxValue = 100;

            // Assert
            Assert.Throws<ArgumentException>(
                // Act
                () => parameter.Value = expected
                );
        }

        [Test(Description =
                "Тест присваивания _minValue и _maxValue в зависимости от типа параметра (Длина)")]
        public void DefaultMinMaxLength()
        {
            // Arrange & Act
            var parameter = new Parameter(BottleParameterType.Length);
            var expectedMin = 10;
            var expectedMax = 250;
            var actualMin = parameter.MinValue;
            var actualMax = parameter.MaxValue;

            // Assert
            Assert.Multiple(
                () =>
                {
                    Assert.AreEqual(expectedMin, actualMin);
                    Assert.AreEqual(expectedMax, actualMax);
                });
        }

        [Test(Description =
                "Тест присваивания _minValue и _maxValue в зависимости от типа параметра (Ширина)"
        )]
        public void DefaultMinMaxWidth()
        {
            // Arrange & Act
            var parameter = new Parameter(BottleParameterType.Width);
            var expectedMin = 10;
            var expectedMax = 250;
            var actualMin = parameter.MinValue;
            var actualMax = parameter.MaxValue;

            // Assert
            Assert.Multiple(
                () =>
                {
                    Assert.AreEqual(expectedMin, actualMin);
                    Assert.AreEqual(expectedMax, actualMax);
                });
        }

        [Test(Description =
            "Тест присваивания _minValue и _maxValue в зависимости от типа параметра (Высота основной части)"
        )]
        public void DefaultMinMaxMainHeight()
        {
            // Arrange & Act
            var parameter = new Parameter(BottleParameterType.MainHeight);
            var expectedMin = 10;
            var expectedMax = 250;
            var actualMin = parameter.MinValue;
            var actualMax = parameter.MaxValue;

            // Assert
            Assert.Multiple(
                () =>
                {
                    Assert.AreEqual(expectedMin, actualMin);
                    Assert.AreEqual(expectedMax, actualMax);
                });
        }

        [Test(Description =
            "Тест присваивания _minValue и _maxValue в зависимости от типа параметра (Высота горлышка)"
        )]
        public void DefaultMinMaxNeckHeight()
        {
            // Arrange & Act
            var parameter = new Parameter(BottleParameterType.NeckHeight);
            var expectedMin = 10;
            var expectedMax = 40;
            var actualMin = parameter.MinValue;
            var actualMax = parameter.MaxValue;

            // Assert
            Assert.Multiple(
                () =>
                {
                    Assert.AreEqual(expectedMin, actualMin);
                    Assert.AreEqual(expectedMax, actualMax);
                });
        }

        [Test(Description =
            "Тест присваивания _minValue и _maxValue в зависимости от типа параметра (Радиус горлышка)"
        )]
        public void DefaultMinMaxNeckRadius()
        {
            // Arrange & Act
            var parameter = new Parameter(BottleParameterType.NeckRadius);
            var expectedMin = 5;
            var expectedMax = 20;
            var actualMin = parameter.MinValue;
            var actualMax = parameter.MaxValue;

            // Assert
            Assert.Multiple(
                () =>
                {
                    Assert.AreEqual(expectedMin, actualMin);
                    Assert.AreEqual(expectedMax, actualMax);
                });
        }

        [Test(Description = 
            "Тест выводимого сообщения при появлении исключения (Длина)")]
        public void ExceptionMessageLength()
        {
            // Arrange
            var parameter = new Parameter(BottleParameterType.Length);
            var expected = "• Длина должна быть в диапазоне 10-250.\n";

            // Assert
            var exception =
                Assert.Throws<ArgumentException>(() => parameter.Value = 1);
            Assert.AreEqual(expected, exception.Message);
        }

        [Test(Description =
            "Тест выводимого сообщения при появлении исключения (Ширина)")]
        public void ExceptionMessageWidth()
        {
            // Arrange
            var parameter = new Parameter(BottleParameterType.Width);
            var expected = "• Ширина должна быть в диапазоне 10-250.\n";

            // Assert
            var exception =
                Assert.Throws<ArgumentException>(() => parameter.Value = 1);
            Assert.AreEqual(expected, exception.Message);
        }

        [Test(Description =
            "Тест выводимого сообщения при появлении исключения (Высота основной части)")]
        public void ExceptionMessageMainHeight()
        {
            // Arrange
            var parameter = new Parameter(BottleParameterType.MainHeight);
            var expected = "• Высота основной части должна быть в диапазоне 10-250.\n";

            // Assert
            var exception =
                Assert.Throws<ArgumentException>(() => parameter.Value = 1);
            Assert.AreEqual(expected, exception.Message);
        }

        [Test(Description =
            "Тест выводимого сообщения при появлении исключения (Высота горлышка)")]
        public void ExceptionMessageNeckHeight()
        {
            // Arrange
            var parameter = new Parameter(BottleParameterType.NeckHeight);
            var expected = "• Высота горлышка должна быть в диапазоне 10-40.\n";

            // Assert
            var exception =
                Assert.Throws<ArgumentException>(() => parameter.Value = 1);
            Assert.AreEqual(expected, exception.Message);
        }

        [Test(Description =
            "Тест выводимого сообщения при появлении исключения (Радиус горлышка)")]
        public void ExceptionMessageNeckRadius()
        {
            // Arrange
            var parameter = new Parameter(BottleParameterType.NeckRadius);
            var expected = "• Радиус горлышка должен быть в диапазоне 5-20.\n";

            // Assert
            var exception =
                Assert.Throws<ArgumentException>(() => parameter.Value = 1);
            Assert.AreEqual(expected, exception.Message);
        }
    }
}