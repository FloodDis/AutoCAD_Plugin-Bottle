using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoCAD_Plugin_Bottle.Model
{
	public static class BottleValidator
	{
		public static void CheckRange(double value,  double min, double max, string objectName)
		{
			if(value < min || value > max)
			{
				var message = $"{objectName} не может быть вне диапазона {min}-{max}.";
				throw new ArgumentException(message);
			}
		}
	}
}
