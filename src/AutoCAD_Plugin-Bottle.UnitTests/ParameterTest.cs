namespace AutoCAD_Plugin_Bottle.UnitTests
{
    [TestFixture]
    public class ParameterTest
    {
        [Test(Description = "���� �������� ���� _maxValue")]
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

        [Test(Description = "���� �������� ���� _minValue")]
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

        [Test(Description = "���� �������� ���� _value (��������)")]
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

        [Test(Description = "���� �������� ���� _value (����������)(������ ��������")]
        public void ValuePropertyFailureLess()
        {
            // Arrange
            var expected = 1;
            var parameter = new Parameter(BottleParameterType.MainHeight);
            parameter.MinValue = 10;
            parameter.MaxValue = 100;

            // Assert
            var exception = Assert.Throws<ArgumentException>(
                // Act
                () => parameter.Value = expected
                );
            Assert.AreEqual("� ������ �������� ����� ������ ���� � ��������� 10-100.\n",
                exception.Message);
        }

        [Test(Description = "���� �������� ���� _value (����������)(������ ���������")]
        public void ValuePropertyFailureMore()
        {
            // Arrange
            var expected = 150;
            var parameter = new Parameter(BottleParameterType.MainHeight);
            parameter.MinValue = 10;
            parameter.MaxValue = 100;

            // Assert
            var exception = Assert.Throws<ArgumentException>(
                // Act
                () => parameter.Value = expected
                );
            Assert.AreEqual("� ������ �������� ����� ������ ���� � ��������� 10-100.\n", 
                exception.Message);
        }
    }
}