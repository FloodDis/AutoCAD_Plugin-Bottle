using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoCAD_Plugin_Bottle.Model
{
    /// <summary>
    /// Бутылка.
    /// </summary>
    public class Bottle
    {
        /// <summary>
        /// Длина основания.
        /// </summary>
        private double _length;

        /// <summary>
        /// Ширина основания.
        /// </summary>
        private double _width;

        /// <summary>
        /// Высота основной части.
        /// </summary>
        private double _mainHeight;

        /// <summary>
        /// Высота горлышка.
        /// </summary>
        private double _neckHeight;

        /// <summary>
        /// Радиус горлышка.
        /// </summary>
        private double _neckRadius;

        /// <summary>
        /// Возвращает или задает длину основания.
        /// </summary>
        public double Length
        {
            get { return _length; }
            set 
            {
                BottleValidator.CheckRange(value, 10, 250, "Длина основания");
                _length = value; 
            }
        }

		/// <summary>
		/// Возвращает или задает ширину основания.
		/// </summary>
		public double Width
        {
            get { return _width; }
            set
            {
                BottleValidator.CheckRange(value, 10, 250, "Ширина основания");
                _width = value;
            }
        }

        /// <summary>
        /// Возвращает или задает высоту основной части.
        /// </summary>
        public double MainHeight
        {
            get { return _mainHeight; }
            set
            {
                BottleValidator.CheckRange(value, 10, 250, "Высота основной части");
                _mainHeight = value;
            }
        }

        /// <summary>
        /// Возвращает или задает высоту горлышка.
        /// </summary>
        public double NeckHeight
        {
            get { return _neckHeight; }
            set
            {
                BottleValidator.CheckRange(value, 10, 40, "Высота горлышка");
                _neckHeight = value;
            }
        }

		/// <summary>
		/// Возвращает или задает радиус горлышка.
		/// </summary>
		public double NeckRadius
        {
            get { return _neckRadius; }
            set
            {
                BottleValidator.CheckRange(value, 5, 20, "Радиус горлышка");
                _neckRadius = value;
            }
        }
    }
}
