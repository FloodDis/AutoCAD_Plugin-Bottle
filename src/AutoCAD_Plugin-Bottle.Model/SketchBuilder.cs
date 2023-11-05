using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Geometry;
using Autodesk.AutoCAD.Windows.ToolPalette;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoCAD_Plugin_Bottle.Model
{
	/// <summary>
	/// Создатель эскизов.
	/// </summary>
	static public class SketchBuilder
	{
		/// <summary>
		/// Создает эскиз в виде окружности.
		/// </summary>
		/// <param name="center">Центр окружности.</param>
		/// <param name="normal">Нормаль окружности.</param>
		/// <param name="radius">Радиус окружности.</param>
		/// <returns>Созданная окружность.</returns>
		static public Region CreateCircle(Point3d center, Vector3d normal, double radius)
		{
			Circle newCircle = new Circle(center, normal, radius);

			DBObjectCollection curves = new DBObjectCollection();
			DBObjectCollection regions = new DBObjectCollection();

			curves.Add(newCircle);
			regions = Region.CreateFromCurves(curves);
			Region region = (Region)regions[0];

			return region;
		}

		/// <summary>
		/// Создает эскиз в виде прямоугольника
		/// </summary>
		/// <param name="width">Ширина прямоугольника.</param>
		/// <param name="length">Длина прямоугольника.</param>
		/// <param name="offset">Отступ от границ тела.</param>
		/// <returns>Прямоугольник.</returns>
		static public Region CreateRectangle(double width, double length, double offset = 0)
		{
			Point3d[] polylinePoints = new Point3d[4];
			double[] dblBulges = new double[3];

			polylinePoints[0] = new Point3d(width - offset, offset, offset);
			polylinePoints[1] = new Point3d(width - offset, length - offset, offset);
			polylinePoints[2] = new Point3d(offset, length - offset, offset);
			polylinePoints[3] = new Point3d(offset, offset, offset);

			DoubleCollection doubles = new DoubleCollection(dblBulges);
			Point3dCollection point3DCollection = new Point3dCollection(polylinePoints);
			Polyline2d outline = new Polyline2d(Poly2dType.SimplePoly, point3DCollection, 0, true, 0, 0, doubles);

			DBObjectCollection curves = new DBObjectCollection();
			DBObjectCollection regions = new DBObjectCollection();

			curves.Add(outline);
			regions = Region.CreateFromCurves(curves);
			Region region = (Region)regions[0];

			return region;
		}
	}
}
