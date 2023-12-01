namespace AutoCAD_Plugin_Bottle.UnitTests
{
    [TestFixture]
    public class SketchBuilderTest
    {
        [Test(Description = "Тест создания эскиза в виде окружности")]
        public void CircleCreation()
        {
            // Arrange
            var center = new Point3d(0, 0, 0);

            // Act
            var circle = SketchBuilder.CreateCircle(center, 10);

            // Assert
            Assert.IsInstanceOf<Region>(circle);
        }

        [Test(Description = "Тест создания эскиза в виде прямоугольника")]
        public void RectangleCreation()
        {
            // Arrange & Act
            var rectangle = SketchBuilder.CreateRectangle(100, 100);

            // Assert
            Assert.IsInstanceOf<Region>(rectangle);
        }
    }
}
