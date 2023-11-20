namespace AutoCAD_Plugin_Bottle.Model
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Параметры модели бутылки.
    /// </summary>
    public class Parameters
    {
        /// <summary>
        /// Конструктор класса.
        /// </summary>
        public Parameters()
        {
            ParameterDictionary = new Dictionary<BottleParameterType, Parameter>
            {
                { BottleParameterType.Length, new Parameter(BottleParameterType.Length) },
                { BottleParameterType.Width, new Parameter(BottleParameterType.Width) },
                { BottleParameterType.MainHeight, new Parameter(BottleParameterType.MainHeight) },
                { BottleParameterType.NeckHeight, new Parameter(BottleParameterType.NeckHeight) },
                { BottleParameterType.NeckRadius, new Parameter(BottleParameterType.NeckRadius) }
            };
        }

        /// <summary>
        /// Авто свойство словаря параметров.
        /// </summary>
        public Dictionary<BottleParameterType, Parameter> ParameterDictionary { get; private set; }

        /// <summary>
        /// Валидирует высоту горлышка бутылки как зависимый параметр.
        /// </summary>
        public void ValidateNeckHeight()
        {
            string message;

            Parameter neckHeight = ParameterDictionary[BottleParameterType.NeckHeight];
            Parameter mainHeight = ParameterDictionary[BottleParameterType.MainHeight];

            if (neckHeight.Value > mainHeight.Value / 4)
            {
                message = "• Высота горлышка должна быть минимум"
                          + " в 4 раза меньше высоты основной части.\n";
                throw new ArgumentException(message);
            }
        }

        /// <summary>
        /// Валидирует радиус горлышка как зависимый параметр.
        /// </summary>
        public void ValidateNeckRadius()
        {
            string message = "";

            Parameter neckRadius = ParameterDictionary[BottleParameterType.NeckRadius];
            Parameter width = ParameterDictionary[BottleParameterType.Width];
            Parameter length = ParameterDictionary[BottleParameterType.Length];

            if (neckRadius.Value > width.Value / 2)
            {
                message += "• Радиус горлышка должен быть минимум" +
                           " в 2 раза меньше ширины основной части.\n";
            }

            if (neckRadius.Value > length.Value / 2)
            {
                message += "• Радиус горлышка должен быть минимум" +
                           " в 2 раза меньше длины основной части.\n";
            }

            if (message != "")
            {
                throw new ArgumentException(message);
            }
        }
    }
}