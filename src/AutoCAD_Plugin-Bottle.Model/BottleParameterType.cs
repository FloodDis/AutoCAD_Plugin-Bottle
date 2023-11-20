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
		Length = 0,

		/// <summary>
		/// Ширина основной части.
		/// </summary>
		Width,

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
		NeckRadius
	}
}
