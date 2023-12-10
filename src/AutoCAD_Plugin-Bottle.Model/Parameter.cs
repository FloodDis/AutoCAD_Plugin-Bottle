namespace AutoCAD_Plugin_Bottle.Model
{
    using System;

    /// <summary>
    /// Параметр.
    /// </summary>
    public class Parameter
	{
        /// <summary>
        /// Значение параметра.
        /// </summary>
        private double _value;

        /// <summary>
        /// Конструктор класса.
        /// </summary>
        /// <param name="minValue">Минимальное значение.</param>
        /// <param name="maxValue">Максимальное значение.</param>
        public Parameter(double minValue, double maxValue)
        {
            MinValue = minValue;
            MaxValue = maxValue;
        }

        /// <summary>
        /// Авто свойство максимального значения параметра.
        /// </summary>
        public double MaxValue { get; set; }

        /// <summary>
        /// Авто свойство минимального значения параметра.
        /// </summary>
        public double MinValue { get; set; }

        /// <summary>
        /// Свойство параметра.
        /// </summary>
        public double Value
        {
            get => _value;
			set
			{
				Validate(value);
				_value = value;
			}
		}

        /// <summary>
        /// Возвращает параметр к дефолтному значению.
        /// </summary>
        public void ReturnToDefaultValue()
        {
            Value = MinValue;
        }

        /// <summary>
        /// Валидирует параметр.
        /// </summary>
        private void Validate(double value)
		{
			if (value < MinValue || value > MaxValue)
            {
				throw new ArgumentException(
                    $"Параметр должен быть в диапазоне {MinValue}-{MaxValue}.\n");
			}
		}
	}
}
