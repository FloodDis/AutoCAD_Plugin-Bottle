namespace AutoCAD_Plugin_Bottle.Model
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Параметры модели бутылки.
    /// </summary>
    public class Parameters
    {
        /// <summary>
        /// Словарь параметров.
        /// </summary>
        private readonly Dictionary<BottleParameterType, Parameter> _parameterDictionary;

        /// <summary>
        /// Словарь ошибок.
        /// </summary>
        private readonly Dictionary<BottleParameterType, List<ArgumentException>> _errorDictionary;

        /// <summary>
        /// Конструктор класса.
        /// </summary>
        public Parameters()
        {
            _parameterDictionary = new Dictionary<BottleParameterType, Parameter>
            {
                { BottleParameterType.MainLength, new Parameter(10, 250) },
                { BottleParameterType.MainWidth, new Parameter(10, 250) },
                { BottleParameterType.MainHeight, new Parameter(10, 250) },
                { BottleParameterType.NeckHeight, new Parameter(10, 40) },
                { BottleParameterType.NeckRadius, new Parameter(5, 20) },
                { BottleParameterType.NeckLength, new Parameter(5, 20) },
                { BottleParameterType.NeckWidth, new Parameter(5, 20) },
                { BottleParameterType.MainRadius, new Parameter(10, 125) }
            };

            _errorDictionary = new Dictionary<BottleParameterType, List<ArgumentException>>
            {
                { BottleParameterType.MainLength, new List<ArgumentException>() },
                { BottleParameterType.MainWidth, new List<ArgumentException>() },
                { BottleParameterType.MainHeight, new List<ArgumentException>() },
                { BottleParameterType.NeckHeight, new List<ArgumentException>() },
                { BottleParameterType.NeckRadius, new List<ArgumentException>() },
                { BottleParameterType.NeckLength, new List<ArgumentException>() },
                { BottleParameterType.NeckWidth, new List<ArgumentException>() },
                { BottleParameterType.MainRadius, new List<ArgumentException>() }
            };
        }

        /// <summary>
        /// Авто свойство флага формы основной части бутылки.
        /// </summary>
        public bool IsMainCircle { get; set; }

        /// <summary>
        /// Авто свойство флага формы горлышка бутылки.
        /// </summary>
        public bool IsNeckRectangle { get; set; }

        /// <summary>
        /// Перегрузка оператора [].
        /// </summary>
        /// <param name="type">Тип параметра.</param>
        /// <returns>Параметр.</returns>
        public Parameter this[BottleParameterType type] => _parameterDictionary[type];

        /// <summary>
        /// Присваивает значение параметру.
        /// </summary>
        /// <param name="type">Тип параметра.</param>
        /// <param name="value">Значение.</param>
        public void SetValue(BottleParameterType type, double value)
        {
            _errorDictionary[type].Clear();

            try
            {
                _parameterDictionary[type].Value = value;
            }
            catch (ArgumentException exception)
            {
                _errorDictionary[type].Add(exception);
            }

            try
            {
                if (type == BottleParameterType.NeckHeight)
                {
                    ValidateNeckHeight();
                }
            }
            catch (ArgumentException exception)
            {
                _errorDictionary[type].Add(exception);
            }

            try
            {
                if (type == BottleParameterType.NeckRadius
                && !IsMainCircle)
                {
                    ValidateNeckRadius();
                }
            }
            catch (ArgumentException exception)
            {
                _errorDictionary[type].Add(exception);
            }

            if (_errorDictionary[type].Any())
            {
                throw new AggregateException(_errorDictionary[type]);
            }
        }

        /// <summary>
        /// Валидирует высоту горлышка бутылки как зависимый параметр.
        /// </summary>
        private void ValidateNeckHeight()
        {
            var neckHeight = this[BottleParameterType.NeckHeight];
            var mainHeight = this[BottleParameterType.MainHeight];

            if (neckHeight.Value > mainHeight.Value / 4)
            {
                var message = "Параметр должен быть минимум"
                              + " в 4 раза меньше высоты основной части.\n";
                throw new ArgumentException(message);
            }
        }

        /// <summary>
        /// Валидирует радиус горлышка как зависимый параметр.
        /// </summary>
        private void ValidateNeckRadius()
        {
            var message = "";

            var neckRadius = this[BottleParameterType.NeckRadius];
            var width = this[BottleParameterType.MainWidth];
            var length = this[BottleParameterType.MainLength];

            if (neckRadius.Value > width.Value / 2)
            {
                message += "Параметр должен быть минимум" +
                           " в 2 раза меньше ширины основной части.";
            }

            if (neckRadius.Value > length.Value / 2)
            {
                message += "Параметр должен быть минимум" +
                           " в 2 раза меньше длины основной части.\n";
            }
            else if (message != "")
            {
                message += "\n";
            }

            if (message != "")
            {
                throw new ArgumentException(message);
            }
        }
    }
}