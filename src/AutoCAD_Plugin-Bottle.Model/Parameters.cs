using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoCAD_Plugin_Bottle.Model
{
	/// <summary>
	/// Параметры модели бутылки.
	/// </summary>
	public class Parameters
	{
		/// <summary>
		/// Словарь параметров.
		/// </summary>
		private Dictionary<ParameterType, Parameter> _parameterDictionary;

		/// <summary>
		/// Свойство словаря параметров.
		/// </summary>
		public Dictionary<ParameterType, Parameter> ParameterDictionary
		{
			get { return _parameterDictionary; }
		}

		/// <summary>
		/// Валидирует зависимые параметры.
		/// </summary>
		/// <exception cref="ArgumentException"></exception>
		public void ValidateDependentParameters()
		{
			Parameter neckHeight = _parameterDictionary[ParameterType.NeckHeight];
			Parameter mainHeight = _parameterDictionary[ParameterType.MainHeight];
			Parameter neckRadius = _parameterDictionary[ParameterType.NeckRadius];
			Parameter width = _parameterDictionary[ParameterType.Width];
			Parameter length = _parameterDictionary[ParameterType.Length];

			var message = "";

			if (neckHeight.Value > mainHeight.Value / 4)
			{
				message += "Высота горлышка должна быть минимум в 4 раза меньше высоты основной части\n";
			}
			if (neckRadius.Value > width.Value / 2)
			{
				message += "Радиус горлышка должны быть минимум в 2 раза меньше ширины основной части\n";
			}
			if (neckRadius.Value > length.Value / 2)
			{
				message += "Радиус горлышка должны быть минимум в 2 раза меньше длины основной части\n";
			}

			if (message != "")
			{
				throw new ArgumentException(message);
			}
		}
	}
}
