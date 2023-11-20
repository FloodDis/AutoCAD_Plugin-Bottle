namespace AutoCAD_Plugin_Bottle.Model
{
    using System;

    /// <summary>
    /// Параметр.
    /// </summary>
    public class Parameter
	{
        /// <summary>
        /// Тип параметра.
        /// </summary>
        private readonly BottleParameterType _parameterType;

        /// <summary>
        /// Значение параметра.
        /// </summary>
        private double _value;

        /// <summary>
        /// Конструктор класса.
        /// </summary>
        /// <param name="parameterType">Тип параметра.</param>
        public Parameter(BottleParameterType parameterType)
        {
            _parameterType = parameterType;
            switch (_parameterType)
            {
                case BottleParameterType.Length:
                {
                    MinValue = 10;
                    MaxValue = 250;
                    break;
                }

                case BottleParameterType.Width:
                {
                    MinValue = 10;
                    MaxValue = 250;
                    break;
                }

                case BottleParameterType.MainHeight:
                {
                    MinValue = 10;
                    MaxValue = 250;
                    break;
                }

                case BottleParameterType.NeckHeight:
                {
                    MinValue = 10;
                    MaxValue = 40;
                    break;
                }

                case BottleParameterType.NeckRadius:
                {
                    MinValue = 5;
                    MaxValue = 20;
                    break;
                }
            }
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
        /// Возвращает название параметра
        /// </summary>
        /// <param name="parameterType"></param>
        /// <returns></returns>
        private string GetNameOfParamter()
        {
            switch (_parameterType)
            {
                case BottleParameterType.Length:
                {
                    return "Длина должна";
                }

                case BottleParameterType.Width:
                {
                    return "Ширина должна";
                }

                case BottleParameterType.MainHeight:
                {
                    return "Высота основной части должна";
                }

                case BottleParameterType.NeckHeight:
                {
                    return "Высота горлышка должна";
                }

                case BottleParameterType.NeckRadius:
                {
                    return "Радиус горлышка должен";
                }

                default:
                {
                    return "";
                }
            }
        }

		/// <summary>
		/// Валидирует параметр.
		/// </summary>
		private void Validate(double value)
		{
			if (value < MinValue || value > MaxValue)
            {
                string parameterName = GetNameOfParamter();
				throw new ArgumentException(
                    $"• {parameterName} быть в диапазоне {MinValue}-{MaxValue}.\n");
			}
		}
	}
}
