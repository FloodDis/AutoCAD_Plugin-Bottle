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
                    var mainLength =
                        parameters[BottleParameterType.MainLength];
                    var mainWidth =
                        parameters[BottleParameterType.MainWidth];
                    var mainHeight =
                        parameters[BottleParameterType.MainHeight];
                    var neckRadius =
                        parameters[BottleParameterType.NeckRadius];
                    var neckHeight =
                        parameters[BottleParameterType.NeckHeight];
                    var neckLength =
                        parameters[BottleParameterType.NeckLength];
                    var neckWidth =
                        parameters[BottleParameterType.NeckWidth];
                    var mainRadius =
                        parameters[BottleParameterType.MainRadius];

                    var mainPart = new Solid3d();
                    var neck = new Solid3d();
                    var shell = new Solid3d();
                    if (parameters.IsMainCircle)
                    {
                        mainPart = BuildMain(mainRadius, mainHeight);
                    }
                    else
                    {
                        mainPart = BuildMain(mainLength, mainWidth, mainHeight);
                    }

                    if (parameters.IsNeckRectangle)
                    {
                        neck = BuildNeck(neckHeight, neckLength, neckWidth, mainHeight);
                        shell = BuildShellSolid(neckLength, neckWidth, mainHeight);
                    }
                    else
                    {
                        neck = BuildNeck(neckHeight, neckRadius, mainHeight);
                        shell = BuildShellSolid(neckRadius, mainHeight);
                    }

                    mainPart.BooleanOperation(BooleanOperationType.BoolSubtract, shell);

                    modelSpace.AppendEntity(mainPart);
                    modelSpace.AppendEntity(neck);
                    modelSpace.AppendEntity(shell);

                    transaction.AddNewlyCreatedDBObject(mainPart, true);
                    transaction.AddNewlyCreatedDBObject(neck, true);
                    transaction.AddNewlyCreatedDBObject(shell, true);

                    transaction.Commit();
                }
            }
        }

        /// <summary>
        /// Строит прямоугольную основную часть бутылки.
        /// </summary>
        /// <param name="mainLength">Длина основной части.</param>
        /// <param name="mainWidth">Высота основной части.</param>
        /// <param name="mainHeight">Высота основной части.</param>
        /// <returns>Основная часть.</returns>
        private static Solid3d BuildMain(
            Parameter mainLength,
            Parameter mainWidth,
            Parameter mainHeight
            )
        {
            var mainCenter = new Point3d(0, 0, 0);
            var mainRectangle = SketchBuilder.CreateRectangle(
                mainWidth.Value,
                mainLength.Value,
                mainCenter);
            var mainPart = new Solid3d();
            mainPart.Extrude(mainRectangle, -mainHeight.Value, 0);

            var shellCenter = new Point3d(0, 0, 2);
            var shellRectangle = SketchBuilder.CreateRectangle(
                mainWidth.Value - 2,
                mainLength.Value - 2,
                shellCenter);
            var mainShellPart = new Solid3d();
            mainShellPart.Extrude(shellRectangle, -(mainHeight.Value - 4), 0);

            mainPart.BooleanOperation(BooleanOperationType.BoolSubtract, mainShellPart);

            return mainPart;
        }

        /// <summary>
        /// Строит круглую основную часть бутылки.
        /// </summary>
        /// <param name="mainRadius">Радиус основания бутылки.</param>
        /// <param name="mainHeight">Высота основной части.</param>
        /// <returns>Основная часть.</returns>
        private static Solid3d BuildMain(
            Parameter mainRadius,
            Parameter mainHeight
            )
        {
            var mainCenter = new Point3d(0, 0, 0);
            var mainCircle = SketchBuilder.CreateCircle(mainCenter, mainRadius.Value);
            var shellCenter = new Point3d(0, 0, 2);
            var shellCircle = SketchBuilder.CreateCircle(
                shellCenter,
                mainRadius.Value - 2);

            var mainPart = new Solid3d();
            mainPart.Extrude(mainCircle, mainHeight.Value, 0);
            var shellPart = new Solid3d();
            shellPart.Extrude(shellCircle, mainHeight.Value - 4, 0);

            mainPart.BooleanOperation(BooleanOperationType.BoolSubtract, shellPart);

            return mainPart;
        }

        /// <summary>
        /// Строит круглое горлышко.
        /// </summary>
        /// <param name="neckHeight">Высота горлышка.</param>
        /// <param name="neckRadius">Радиус горлышка.</param>
        /// <param name="mainHeight">Высота основной части.</param>
        /// <returns>Горлышко бутылки.</returns>
        private static Solid3d BuildNeck(
            Parameter neckHeight,
            Parameter neckRadius,
            Parameter mainHeight)
        {
            var center = new Point3d(0, 0, mainHeight.Value);
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

        /// <summary>
        /// Строит прямоугольное горлышко.
        /// </summary>
        /// <param name="neckHeight">Высота горлышка.</param>
        /// <param name="neckLength">Длина горлышка.</param>
        /// <param name="neckWidth">Ширина горлышка.</param>
        /// <param name="mainHeight">Высота основной части.</param>
        /// <returns>Прямоугольное горлышко.</returns>
        private static Solid3d BuildNeck(
            Parameter neckHeight,
            Parameter neckLength,
            Parameter neckWidth,
            Parameter mainHeight
        )
        {
            var center = new Point3d(0, 0, mainHeight.Value);
            var circle = SketchBuilder.CreateRectangle(
            neckWidth.Value, neckLength.Value, center);
            var neck = new Solid3d();
            neck.Extrude(circle, -neckHeight.Value, 0);

            var shellRectangle = SketchBuilder.CreateRectangle(
                neckWidth.Value - 2,
                neckLength.Value - 2,
                center);
            var shell = new Solid3d();
            shell.Extrude(shellRectangle, -neckHeight.Value, 0);

            neck.BooleanOperation(BooleanOperationType.BoolSubtract, shell);

            return neck;
        }

        /// <summary>
        /// Создает прямоугольный Solid3d для вырезания отверстия.
        /// </summary>
        /// <param name="neckLength">Длина горлышка.</param>
        /// <param name="neckWidth">Ширина горлышка.</param>
        /// <param name="mainHeight">Высота основной части.</param>
        /// <returns>Прямоугольный Solid3d для вырезания отверстия.</returns>
        private static Solid3d BuildShellSolid(
            Parameter neckLength,
            Parameter neckWidth,
            Parameter mainHeight
        )
        {
            var shellCenter = new Point3d(0, 0, mainHeight.Value);
            var shellSketch = SketchBuilder.CreateRectangle(
                neckWidth.Value,
                neckLength.Value,
                shellCenter);

            var shellSolid = new Solid3d();
            shellSolid.Extrude(shellSketch, 2, 0);
            return shellSolid;
        }

        /// <summary>
        /// Создает круглый Solid3d для вырезания отверстия.
        /// </summary>
        /// <param name="neckRadius">Радиус горлышка.</param>
        /// <param name="mainHeight">Высота основной части.</param>
        /// <returns>Круглый Solid3d для вырезания отверстия.</returns>
        private static Solid3d BuildShellSolid(
            Parameter neckRadius,
            Parameter mainHeight
        )
        {
            var shellCenter = new Point3d(0, 0, mainHeight.Value);
            var shellSketch = SketchBuilder.CreateCircle(
                shellCenter,
                neckRadius.Value - 2);

            var shellSolid = new Solid3d();
            shellSolid.Extrude(shellSketch, -2, 0);
            return shellSolid;
        }
    }
}
