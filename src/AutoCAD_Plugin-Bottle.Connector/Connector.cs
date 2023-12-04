namespace AutoCAD_Plugin_Bottle.Connector
{
    using AutoCAD_Plugin_Bottle.View;
    using Autodesk.AutoCAD.Runtime;

    /// <summary>
    /// Обертка плагина.
    /// </summary>
    public static class Connector
	{
        /// <summary>
        /// Открывает приложение.
        /// </summary>
        [CommandMethod("BottleBuilder")]
        public static void OpenApp()
        {
            MainForm mainForm = new MainForm();
            mainForm.Show();
        }
	}
}