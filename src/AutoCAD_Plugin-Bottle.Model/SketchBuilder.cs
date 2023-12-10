namespace AutoCAD_Plugin_Bottle.Model
{
    using Autodesk.AutoCAD.DatabaseServices;
    using Autodesk.AutoCAD.Geometry;

    /// <summary>
    /// Создатель эскизов.
    /// </summary>
    public static class SketchBuilder
    {
        /// <summary>
        /// Создает эскиз в виде окружности.
        /// </summary>
        /// <param name="center">Центр окружности.</param>
        /// <param name="normal">Нормаль окружности.</param>
        /// <param name="radius">Радиус окружности.</param>
        /// <returns>Созданная окружность.</returns>
        public static Region CreateCircle(Point3d center, double radius)
        {
            Polyline newCircle = new Polyline();
            newCircle.AddVertexAt(
                0,
                new Point2d(center.X + radius, center.Y),
                1.0,
                0.0,
                0.0);
            newCircle.AddVertexAt(
                1,
                new Point2d(center.X - radius, center.Y),
                1.0,
                0.0,
                0.0);
            newCircle.Elevation = center.Z;
            newCircle.Closed = true;

            using (DBObjectCollection curves = new DBObjectCollection())
            {
                curves.Add(newCircle);
                using (DBObjectCollection regions = Region.CreateFromCurves(curves))
                {
                    Region region = (Region)regions[0];

                    return region;
                }
            }
        }

        /// <summary>
        /// Создает эскиз в виде прямоугольника.
        /// </summary>
        /// <param name="width">Ширина прямоугольника.</param>
        /// <param name="length">Длина прямоугольника.</param>
        /// <param name="center">Центр прямоугольника.</param>
        /// <returns>Прямоугольник.</returns>
        public static Region CreateRectangle(
            double width,
            double length,
            Point3d center)
        {
            Point3d[] polylinePoints = new Point3d[4];

            polylinePoints[0] = new Point3d(
                center.X - (length / 2),
                center.Y - (width / 2),
                center.Z);
            polylinePoints[1] = new Point3d(
                center.X - (length / 2),
                center.Y + (width / 2),
                center.Z);
            polylinePoints[2] = new Point3d(
                center.X + (length / 2),
                center.Y + (width / 2),
                center.Z);
            polylinePoints[3] = new Point3d(
                center.X + (length / 2),
                center.Y - (width / 2),
                center.Z);

            Point3dCollection point3DCollection = new Point3dCollection(polylinePoints);
            Polyline3d outline = new Polyline3d(
                Poly3dType.SimplePoly,
                point3DCollection,
                true
                );

            DBObjectCollection curves = new DBObjectCollection();
            DBObjectCollection regions = new DBObjectCollection();

            curves.Add(outline);
            regions = Region.CreateFromCurves(curves);
            Region region = (Region)regions[0];

            return region;
        }
    }
}
