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
        public static void BuildBottle(Parameters parameters)
        {
            var currentDocument = Autodesk.AutoCAD.ApplicationServices.
                Application.DocumentManager.MdiActiveDocument;
            using (var documentLock = currentDocument.LockDocument())
            {
                using (var transaction = Autodesk.AutoCAD.
                    ApplicationServices.Application.DocumentManager.
                    MdiActiveDocument.Database.
                    TransactionManager.StartTransaction())
                {
                    Database db =
                        Autodesk.AutoCAD.ApplicationServices.Core.
                            Application.DocumentManager.MdiActiveDocument.Database;
                    BlockTableRecord modelSpace =
                        (BlockTableRecord)transaction.GetObject(
                            SymbolUtilityServices.GetBlockModelSpaceId(db),
                            OpenMode.ForWrite,
                            false,
                            true);
                    var length =
                        parameters[BottleParameterType.Length];
                    var width =
                        parameters[BottleParameterType.Width];
                    var mainHeight =
                        parameters[BottleParameterType.MainHeight];
                    var neckRadius =
                        parameters[BottleParameterType.NeckRadius];
                    var neckHeight =
                        parameters[BottleParameterType.NeckHeight];

                    var mainPart = BuildMainPart(
                        length,
                        width,
                        mainHeight,
                        neckRadius);
                    var neck = BuildNeck(
                        neckHeight,
                        neckRadius,
                        width,
                        length,
                        mainHeight);

                    modelSpace.AppendEntity(mainPart);
                    modelSpace.AppendEntity(neck);

                    transaction.AddNewlyCreatedDBObject(mainPart, true);
                    transaction.AddNewlyCreatedDBObject(neck, true);

                    transaction.Commit();
                }
            }
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
            var mainRectangle = SketchBuilder.CreateRectangle(
                width.Value,
                length.Value);
            var mainPart = new Solid3d();
            mainPart.Extrude(mainRectangle, mainHeight.Value, 0);

            var shellRectangle = SketchBuilder.CreateRectangle(
                width.Value,
                length.Value,
                2);
            var mainShellPart = new Solid3d();
            mainShellPart.Extrude(shellRectangle, mainHeight.Value - 4, 0);

            var center = new Point3d(
                width.Value / 2,
                length.Value / 2,
                mainHeight.Value);
            var hole = SketchBuilder.CreateCircle(
                center,
                neckRadius.Value - 2);
            var circleShellPart = new Solid3d();
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
            var center = new Point3d(
                width.Value / 2,
                length.Value / 2,
                mainHeight.Value);
            var circle = SketchBuilder.CreateCircle(
                center,
                neckRadius.Value);
            var neck = new Solid3d();
            neck.Extrude(circle, neckHeight.Value, 0);

            var shellCircle = SketchBuilder.CreateCircle(
                center,
                neckRadius.Value - 2);
            var shell = new Solid3d();
            shell.Extrude(shellCircle, neckHeight.Value, 0);

            neck.BooleanOperation(BooleanOperationType.BoolSubtract, shell);

            return neck;
        }
    }
}
