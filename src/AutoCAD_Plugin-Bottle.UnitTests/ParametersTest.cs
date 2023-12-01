namespace AutoCAD_Plugin_Bottle.UnitTests
{
    [TestFixture]
    public class ParametersTest
    {
        [Test(Description = "Тест свойства поля _parameterDictionary")]
        public void ParameterDictionaryProperty()
        {
           // Arrange & Act
           var parameters = new Parameters();
           var parameterDictionary = parameters.ParameterDictionary;
           
           // Assert
           Assert.IsInstanceOf<Dictionary<BottleParameterType, Parameter>>(parameterDictionary);
        }

        [Test(Description = "Тест валидации высоты горлышка")]
        public void NeckHeightValidation()
        {
            // Arrange
            var parameters = new Parameters();
            parameters.ParameterDictionary[BottleParameterType.NeckHeight].Value = 10;
            parameters.ParameterDictionary[BottleParameterType.MainHeight].Value = 10;
            var expected = "• Высота горлышка должна быть минимум"
                         + " в 4 раза меньше высоты основной части.\n";

            // Assert
            var exception = Assert.Throws<ArgumentException>(
                // Act
                () => parameters.ValidateNeckHeight()
                );
            Assert.AreEqual(expected, exception.Message);
        }

        [Test(Description = "Тест валидации радиуса горлышка (ширина - успех, длина - провал)")]
        public void NeckRadiusValidationLength()
        {
            // Arrange
            var parameters = new Parameters();
            parameters.ParameterDictionary[BottleParameterType.Width].Value = 100;
            parameters.ParameterDictionary[BottleParameterType.Length].Value = 10;
            parameters.ParameterDictionary[BottleParameterType.NeckRadius].Value = 10;
            var expected = "• Радиус горлышка должен быть минимум"
                           + " в 2 раза меньше длины основной части.\n";

            // Assert
            var exception = Assert.Throws<ArgumentException>(
                // Act
                () => parameters.ValidateNeckRadius()
                );
            Assert.AreEqual(expected, exception.Message);
        }

        [Test(Description = "Тест валидации радиуса горлышка (ширина - провал, длина - успех)")]
        public void NeckRadiusValidationWidth()
        {
            // Arrange
            var parameters = new Parameters();
            parameters.ParameterDictionary[BottleParameterType.Width].Value = 10;
            parameters.ParameterDictionary[BottleParameterType.Length].Value = 100;
            parameters.ParameterDictionary[BottleParameterType.NeckRadius].Value = 10;
            var expected = "• Радиус горлышка должен быть минимум"
                           + " в 2 раза меньше ширины основной части.\n";

            // Assert
            var exception = Assert.Throws<ArgumentException>(
                // Act
                () => parameters.ValidateNeckRadius()
            );
            Assert.AreEqual(expected, exception.Message);
        }

        [Test(Description = "Тест валидации радиуса горлышка (ширина - провал, длина - провал)")]
        public void NeckRadiusValidationWidthLength()
        {
            // Arrange
            var parameters = new Parameters();
            parameters.ParameterDictionary[BottleParameterType.Width].Value = 10;
            parameters.ParameterDictionary[BottleParameterType.Length].Value = 10;
            parameters.ParameterDictionary[BottleParameterType.NeckRadius].Value = 10;
            var expected = "• Радиус горлышка должен быть минимум"
                           + " в 2 раза меньше ширины основной части.\n"
                           + "• Радиус горлышка должен быть минимум"
                           + " в 2 раза меньше длины основной части.\n";

            // Assert
            var exception = Assert.Throws<ArgumentException>(
                // Act
                () => parameters.ValidateNeckRadius()
            );
            Assert.AreEqual(expected, exception.Message);
        }
    }
}
