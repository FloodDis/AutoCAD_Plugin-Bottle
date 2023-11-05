using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoCAD_Plugin_Bottle.Model
{
	/// <summary>
	/// Параметр.
	/// </summary>
	public class Parameter
	{
		/// <summary>
		/// Максимальное значение параметра.
		/// </summary>
		private double _maxValue;

		/// <summary>
		/// Минимальное значение параметра.
		/// </summary>
		private double _minValue;

		/// <summary>
		/// Значение параметра.
		/// </summary>
		private double _value;

		/// <summary>
		/// Свойство максимального значения параметра.
		/// </summary>
		public double MaxValue
		{
			get { return _maxValue; }
			set
			{
				_maxValue = value;
			}
		}

		/// <summary>
		/// Свойство минмиального значения параметра.
		/// </summary>
		public double MinValue
		{
			get { return _minValue; }
			set
			{
				_minValue = value;
			}
		}

		/// <summary>
		/// Свойство параметра.
		/// </summary>
		public double Value
		{
			get { return _value; }
			set
			{
				Validate();
				_value = value;
			}
		}

		/// <summary>
		/// Валидирует параметр.
		/// </summary>
		private void Validate()
		{
			if (_value < _minValue || _value > _maxValue)
			{
				throw new ArgumentException($"Параметр должен быть в диапазоне {_minValue}-{_maxValue}.");
			}
		}
	}
}
