namespace AutoCAD_Plugin_Bottle.Model
{
	/// <summary>
	/// Тип параметра.
	/// </summary>
	public enum BottleParameterType
	{
		/// <summary>
		/// Длина основной части.
		/// </summary>
		MainLength = 0,

		/// <summary>
		/// Ширина основной части.
		/// </summary>
		MainWidth,

		/// <summary>
		/// Высота основной части.
		/// </summary>
		MainHeight,

		/// <summary>
		/// Высота горлышка.
		/// </summary>
		NeckHeight,

		/// <summary>
		/// Радиус горлышка.
		/// </summary>
		NeckRadius,

        /// <summary>
        /// Радиус основной части.
        /// </summary>
        MainRadius,

        /// <summary>
        /// Длина горлышка.
        /// </summary>
        NeckLength,

        /// <summary>
        /// Ширина горлышка.
        /// </summary>
        NeckWidth
	}
}
