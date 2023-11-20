namespace AutoCAD_Plugin_Bottle.Model
{
    using Autodesk.AutoCAD.DatabaseServices;
    using Autodesk.AutoCAD.Geometry;

    /// <summary>
    /// Строитель модели.
    /// </summary>
    public static class Builder
	{
        /// <summary>
        /// Создает модель бутылки.
        /// </summary>
        /// <param name="parameters">Параметры модели.</param>
        /// <param name="transaction">Транзакция.</param>
        public static void BuildBottle(Parameters parameters, Transaction transaction)
        {
            Parameter length = parameters.ParameterDictionary[BottleParameterType.Length];
            Parameter width = parameters.ParameterDictionary[BottleParameterType.Width];
            Parameter mainHeight = parameters.ParameterDictionary[BottleParameterType.MainHeight];
            Parameter neckRadius = parameters.ParameterDictionary[BottleParameterType.NeckRadius];
            Parameter neckHeight = parameters.ParameterDictionary[BottleParameterType.NeckHeight];

            Solid3d neck = BuildNeck(neckHeight, neckRadius, width, length, mainHeight);
            Solid3d mainPart = BuildMainPart(length, width, mainHeight, neckRadius);

            Database db =
                Autodesk.AutoCAD.ApplicationServices.Core.
                    Application.DocumentManager.MdiActiveDocument.Database;
            BlockTableRecord modelSpace =
                (BlockTableRecord)transaction.GetObject(
                    SymbolUtilityServices.GetBlockModelSpaceId(db),
                    OpenMode.ForWrite,
                    false,
                    true);

            modelSpace.AppendEntity(mainPart);
            modelSpace.AppendEntity(neck);

            transaction.AddNewlyCreatedDBObject(mainPart, true);
            transaction.AddNewlyCreatedDBObject(neck, true);

            transaction.Commit();
        }

        /// <summary>
        /// Строит основную часть бутылки.
        /// </summary>
        /// <param name="length">Длина основной части.</param>
        /// <param name="width">Высота основной части.</param>
        /// <param name="mainHeight">Высота основной части.</param>
        /// <param name="neckRadius">Радиус горлышка.</param>
        /// <returns>Созданная основная часть.</returns>
        private static Solid3d BuildMainPart(
            Parameter length,
            Parameter width,
            Parameter mainHeight,
            Parameter neckRadius)
		{
			Region mainRectangle = SketchBuilder.CreateRectangle(
                width.Value,
                length.Value);
			Solid3d mainPart = new Solid3d();
			mainPart.Extrude(mainRectangle, mainHeight.Value, 0);

			Region shellRectangle = SketchBuilder.CreateRectangle(
                width.Value,
                length.Value,
                2);
			Solid3d mainShellPart = new Solid3d();
			mainShellPart.Extrude(shellRectangle, mainHeight.Value - 2, 0);

			Point3d center = new Point3d(
                width.Value / 2,
                length.Value / 2,
                mainHeight.Value);
			Region hole = SketchBuilder.CreateCircle(
                center,
                mainRectangle.Normal,
                neckRadius.Value);
			Solid3d circleShellPart = new Solid3d();
			circleShellPart.Extrude(hole, -2, 0);

			mainPart.BooleanOperation(BooleanOperationType.BoolSubtract, mainShellPart);
			mainPart.BooleanOperation(BooleanOperationType.BoolSubtract, circleShellPart);

			return mainPart;
		}

		/// <summary>
		/// Строит горлышко бутылки.
		/// </summary>
		/// <param name="neckHeight">Высота горлышка.</param>
		/// <param name="neckRadius">Радиус горлышка.</param>
		/// <param name="width">Ширина основной части.</param>
		/// <param name="length">Длина основной части.</param>
		/// <param name="mainHeight">Высота основной части.</param>
		/// <returns>Горлышко бутылки.</returns>
		private static Solid3d BuildNeck(
            Parameter neckHeight,
            Parameter neckRadius,
			Parameter width,
            Parameter length,
            Parameter mainHeight)
		{
			Point3d center = new Point3d(
                width.Value / 2,
                length.Value / 2,
                mainHeight.Value);
			Region circle = SketchBuilder.CreateCircle(
                center,
                new Vector3d(0, 0, 0),
                neckRadius.Value);
			Solid3d neck = new Solid3d();
			neck.Extrude(circle, mainHeight.Value, 0);

			Region shellCircle = SketchBuilder.CreateCircle(
                center,
                circle.Normal,
                neckRadius.Value - 2);
			Solid3d shell = new Solid3d();
			shell.Extrude(shellCircle, neckHeight.Value, 0);

			neck.BooleanOperation(BooleanOperationType.BoolSubtract, shell);

			return neck;
		}
	}
}
