namespace AutoCAD_Plugin_Bottle.UnitTests
{
    [TestFixture]
    public class ParametersTest
    {
        [Test(Description = "Тест перегрузки оператора [] (Длина)")]
        public void BracketsOperatorLength()
        {
            // Arrange
            var parameters = new Parameters();
            var expectedMin = 10;
            var expectedMax = 250;

            // Act
            var actualParameter = parameters[BottleParameterType.Length];
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

        [Test(Description = "Тест перегрузки оператора [] (Ширина)")]
        public void BracketsOperatorWidth()
        {
            // Arrange
            var parameters = new Parameters();
            var expectedMin = 10;
            var expectedMax = 250;

            // Act
            var actualParameter = parameters[BottleParameterType.Width];
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

        [Test(Description = "Тест перегрузки оператора [] (Высота основной части)")]
        public void BracketsOperatorMainHeight()
        {
            // Arrange
            var parameters = new Parameters();
            var expectedMin = 10;
            var expectedMax = 250;

            // Act
            var actualParameter = parameters[BottleParameterType.MainHeight];
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

        [Test(Description = "Тест перегрузки оператора [] (Высота горлышка)")]
        public void BracketsOperatorNeckHeight()
        {
            // Arrange
            var parameters = new Parameters();
            var expectedMin = 10;
            var expectedMax = 40;

            // Act
            var actualParameter = parameters[BottleParameterType.NeckHeight];
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
        [Test(Description = "Тест перегрузки оператора [] (Радиус горлышка)")]
        public void BracketsOperatorNeckRadius()
        {
            // Arrange
            var parameters = new Parameters();
            var expectedMin = 5;
            var expectedMax = 20;

            // Act
            var actualParameter = parameters[BottleParameterType.NeckRadius];
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

        [Test(Description = "Тест функции SetValue(успех, Длина)")]
        public void SetValueSuccessLength()
        {
            // Arrange
            var parameters = new Parameters();
            var expected = 100;

            // Act
            parameters.SetValue(BottleParameterType.Length, expected);
            var actual = parameters[BottleParameterType.Length].Value;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test(Description = "Тест функции SetValue(успех, Ширина)")]
        public void SetValueSuccessWidth()
        {
            // Arrange
            var parameters = new Parameters();
            var expected = 100;

            // Act
            parameters.SetValue(BottleParameterType.Width, expected);
            var actual = parameters[BottleParameterType.Width].Value;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test(Description = "Тест функции SetValue(успех, Высота основной части)")]
        public void SetValueSuccessMainHeight()
        {
            // Arrange
            var parameters = new Parameters();
            var expected = 100;

            // Act
            parameters.SetValue(BottleParameterType.MainHeight, expected);
            var actual = parameters[BottleParameterType.MainHeight].Value;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test(Description = "Тест функции SetValue(успех, Высота горлышка)")]
        public void SetValueSuccessNeckHeight()
        {
            // Arrange
            var parameters = new Parameters();
            var expected = 20;
            parameters.SetValue(BottleParameterType.MainHeight, 100);

            // Act
            parameters.SetValue(BottleParameterType.NeckHeight, expected);
            var actual = parameters[BottleParameterType.NeckHeight].Value;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test(Description = "Тест функции SetValue(успех, Радиус горлышка)")]
        public void SetValueSuccessNeckRadius()
        {
            // Arrange
            var parameters = new Parameters();
            var expected = 10;
            parameters.SetValue(BottleParameterType.Length, 100);
            parameters.SetValue(BottleParameterType.Width, 100);

            // Act
            parameters.SetValue(BottleParameterType.NeckRadius, expected);
            var actual = parameters[BottleParameterType.NeckRadius].Value;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test(Description = "Тест функции SetValue(провал, Длина)")]
        public void SetValueFailureLength()
        {
            // Arrange
            var parameters = new Parameters();
            var parameter = parameters[BottleParameterType.Length];
            var expected = 1;
            var expectedMessage =
                $"Параметр должен быть в диапазоне {parameter.MinValue}-{parameter.MaxValue}.\n";

            // Assert & Act
            var exception = Assert.Throws<AggregateException>(
                () => parameters.SetValue(BottleParameterType.Length, expected));

            Assert.AreEqual(expectedMessage, exception.InnerExceptions[0].Message);
        }

        [Test(Description = "Тест функции SetValue(провал, Ширина)")]
        public void SetValueFailureWidth()
        {
            // Arrange
            var parameters = new Parameters();
            var parameter = parameters[BottleParameterType.Width];
            var expected = 1;
            var expectedMessage =
                $"Параметр должен быть в диапазоне {parameter.MinValue}-{parameter.MaxValue}.\n";

            // Assert & Act
            var exception = Assert.Throws<AggregateException>(
                () => parameters.SetValue(BottleParameterType.Width, expected));

            Assert.AreEqual(expectedMessage, exception.InnerExceptions[0].Message);
        }

        [Test(Description = "Тест функции SetValue(провал, Высота основной части)")]
        public void SetValueFailureMainHeight()
        {
            // Arrange
            var parameters = new Parameters();
            var parameter = parameters[BottleParameterType.MainHeight];
            var expected = 1;
            var expectedMessage =
                $"Параметр должен быть в диапазоне {parameter.MinValue}-{parameter.MaxValue}.\n";

            // Assert & Act
            var exception = Assert.Throws<AggregateException>(
                () => parameters.SetValue(BottleParameterType.MainHeight, expected));

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

        [Test(Description =
            "Тест функции SetValue(провал, Радиус горлышка," +
            " не соответствует условию зав. парам., ширина-успех, длина-провал)")
        ]
        public void SetValueFailureNeckRadiusOne()
        {
            // Arrange
            var parameters = new Parameters();
            var parameter = parameters[BottleParameterType.NeckRadius];
            var expected = 10;
            var expectedMessage =
                "Параметр должен быть минимум" +
                " в 2 раза меньше длины основной части.\n";
            parameters.SetValue(BottleParameterType.Width, 100);
            parameters.SetValue(BottleParameterType.Length, 10);


            // Assert & Act
            var exception = Assert.Throws<AggregateException>(
                () => parameters.SetValue(BottleParameterType.NeckRadius, expected));

            Assert.AreEqual(expectedMessage, exception.InnerExceptions[0].Message);
        }

        [Test(Description =
            "Тест функции SetValue(провал, Радиус горлышка," +
            " не соответствует условию зав. парам., ширина-провал, длина-успех)")
        ]
        public void SetValueFailureNeckRadiusTwo()
        {
            // Arrange
            var parameters = new Parameters();
            var parameter = parameters[BottleParameterType.NeckRadius];
            var expected = 10;
            var expectedMessage =
                "Параметр должен быть минимум" +
                " в 2 раза меньше ширины основной части.\n";
            parameters.SetValue(BottleParameterType.Width, 10);
            parameters.SetValue(BottleParameterType.Length, 100);


            // Assert & Act
            var exception = Assert.Throws<AggregateException>(
                () => parameters.SetValue(BottleParameterType.NeckRadius, expected));

            Assert.AreEqual(expectedMessage, exception.InnerExceptions[0].Message);
        }

        [Test(Description =
            "Тест функции SetValue(провал, Радиус горлышка," +
            " не соответствует условию зав. парам., ширина-провал, длина-провал)")
        ]
        public void SetValueFailureNeckRadiusThree()
        {
            // Arrange
            var parameters = new Parameters();
            var parameter = parameters[BottleParameterType.NeckRadius];
            var expected = 10;
            var expectedMessage =
                "Параметр должен быть минимум" +
                " в 2 раза меньше ширины основной части." +
                "Параметр должен быть минимум" +
                " в 2 раза меньше длины основной части.\n";
            parameters.SetValue(BottleParameterType.Width, 10);
            parameters.SetValue(BottleParameterType.Length, 10);


            // Assert & Act
            var exception = Assert.Throws<AggregateException>(
                () => parameters.SetValue(BottleParameterType.NeckRadius, expected));

            Assert.AreEqual(expectedMessage, exception.InnerExceptions[0].Message);
        }
    }
}
