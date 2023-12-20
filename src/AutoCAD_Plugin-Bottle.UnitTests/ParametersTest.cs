namespace AutoCAD_Plugin_Bottle.UnitTests
{
    [TestFixture]
    public class ParametersTest
    {
        [Test(Description = "Тест перегрузки оператора []")]
        [TestCase(BottleParameterType.MainLength, 10, 250)]
        [TestCase(BottleParameterType.MainWidth, 10, 250)]
        [TestCase(BottleParameterType.MainHeight, 10, 250)]
        [TestCase(BottleParameterType.NeckHeight, 10, 40)]
        [TestCase(BottleParameterType.NeckRadius, 5, 20)]
        [TestCase(BottleParameterType.NeckLength, 5, 20)]
        [TestCase(BottleParameterType.NeckWidth, 5, 20)]
        [TestCase(BottleParameterType.MainRadius, 10, 125)]
        public void BracketsOperator(BottleParameterType type, double min, double max)
        {
            // Arrange
            var parameters = new Parameters();
            var expectedMin = min;
            var expectedMax = max;

            // Act
            var actualParameter = parameters[type];
            var actualMin = actualParameter.MinValue;
            var actualMax = actualParameter.MaxValue;

            // Assert
            Assert.Multiple(
                () =>
                {
                    Assert.AreEqual(expectedMin, actualMin);
                    Assert.AreEqual(expectedMax, actualMax);
                });
        }

        [Test(Description = "Тест авто свойства IsMainCircle")]
        public void IsMainCircleProperty()
        {
            // Arrange
            var parameters = new Parameters();
            var expected = true;

            // Act
            parameters.IsMainCircle = expected;
            var actual = parameters.IsMainCircle;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test(Description = "Тест авто свойства IsNeckRectangle")]
        public void IsNeckRectangleProperty()
        {
            // Arrange
            var parameters = new Parameters();
            var expected = true;

            // Act
            parameters.IsNeckRectangle = expected;
            var actual = parameters.IsNeckRectangle;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test(Description = "Тест функции SetValue(успех)")]
        [TestCase(BottleParameterType.MainLength, 100)]
        [TestCase(BottleParameterType.MainWidth, 100)]
        [TestCase(BottleParameterType.MainHeight, 100)]
        [TestCase(BottleParameterType.NeckHeight, 20)]
        [TestCase(BottleParameterType.NeckRadius, 10)]
        [TestCase(BottleParameterType.NeckLength, 10)]
        [TestCase(BottleParameterType.NeckWidth, 10)]
        [TestCase(BottleParameterType.MainRadius, 50)]
        public void SetValueSuccess(BottleParameterType type, double value)
        {
            // Arrange
            var parameters = new Parameters();
            var expected = value;
            if (type == BottleParameterType.NeckHeight)
            {
                parameters.SetValue(BottleParameterType.MainHeight, 100);
            }
            else if (type == BottleParameterType.NeckRadius)
            {
                parameters.SetValue(BottleParameterType.MainWidth, 100);
                parameters.SetValue(BottleParameterType.MainLength, 100);
            }

            // Act
            parameters.SetValue(type, expected);
            var actual = parameters[type].Value;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test(Description = "Тест SetValue(провал)")]
        [TestCase(BottleParameterType.MainLength, 1)]
        [TestCase(BottleParameterType.MainWidth, 1)]
        [TestCase(BottleParameterType.MainHeight, 1)]
        [TestCase(BottleParameterType.NeckLength, 1)]
        [TestCase(BottleParameterType.NeckWidth, 1)]
        [TestCase(BottleParameterType.MainRadius, 1)]

        public void SetValueFailure(BottleParameterType type, double value)
        {
            // Arrange
            var parameters = new Parameters();
            var parameter = parameters[type];
            var expected = value;
            var expectedMessage =
                $"Параметр должен быть в диапазоне {parameter.MinValue}-{parameter.MaxValue}.\n";

            // Assert & Act
            var exception = Assert.Throws<AggregateException>(
                () => parameters.SetValue(type, expected));

            Assert.AreEqual(expectedMessage, exception.InnerExceptions[0].Message);
        }

        [Test(Description =
            "Тест функции SetValue(провал, Высота горлышка, соответствует условию зав. парам.)")
        ]
        public void SetValueFailureNeckHeightOne()
        {
            // Arrange
            var parameters = new Parameters();
            var parameter = parameters[BottleParameterType.NeckHeight];
            var expected = 8;
            var expectedMessage =
                $"Параметр должен быть в диапазоне {parameter.MinValue}-{parameter.MaxValue}.\n";
            parameters.SetValue(BottleParameterType.MainHeight, 100);

            // Assert & Act
            var exception = Assert.Throws<AggregateException>(
                () => parameters.SetValue(BottleParameterType.NeckHeight, expected));

            Assert.AreEqual(expectedMessage, exception.InnerExceptions[0].Message);
        }

        [Test(Description =
            "Тест функции SetValue(успех, Высота горлышка, не соответствует условию зав. парам.)")
        ]
        public void SetValueFailureNeckHeightTwo()
        {
            // Arrange
            var parameters = new Parameters();
            var parameter = parameters[BottleParameterType.NeckHeight];
            var expected = 40;
            var expectedMessage =
                "Параметр должен быть минимум"
                + " в 4 раза меньше высоты основной части.\n";
            parameters.SetValue(BottleParameterType.MainHeight, 40);

            // Assert & Act
            var exception = Assert.Throws<AggregateException>(
                () => parameters.SetValue(BottleParameterType.NeckHeight, expected));

            Assert.AreEqual(expectedMessage, exception.InnerExceptions[0].Message);
        }

        [Test(Description = "Тест функции SetValue(провал, Радиус горлышка)" +
            "не соответствует условию зав. парам.")]
        [TestCase(10, 100, 10, "Параметр должен быть минимум" +
                " в 2 раза меньше длины основной части.\n")]
        [TestCase(10, 10, 100, "Параметр должен быть минимум" +
                " в 2 раза меньше ширины основной части.\n")]
        [TestCase(10, 10, 10, "Параметр должен быть минимум" +
                " в 2 раза меньше ширины основной части." +
                "Параметр должен быть минимум" +
                " в 2 раза меньше длины основной части.\n")]
        public void SetValueFailureNeckRadius(
            double value,
            double width,
            double length,
            string message)
        {
            // Arrange
            var parameters = new Parameters();
            var parameter = parameters[BottleParameterType.NeckRadius];
            var expected = value;
            var expectedMessage = message;
            parameters.SetValue(BottleParameterType.MainWidth, width);
            parameters.SetValue(BottleParameterType.MainLength, length);

            // Assert & Act
            var exception = Assert.Throws<AggregateException>(
                () => parameters.SetValue(BottleParameterType.NeckRadius, expected));

            Assert.AreEqual(expectedMessage, exception.InnerExceptions[0].Message);
        }
    }
}
