namespace AutoCAD_Plugin_Bottle.Connector
{
    using AutoCAD_Plugin_Bottle.View;
    using Autodesk.AutoCAD.ApplicationServices;
    using Autodesk.AutoCAD.DatabaseServices;
    using Autodesk.AutoCAD.Runtime;

    /// <summary>
    /// Обертка плагина.
    /// </summary>
    public static class Wrapper
	{
        /// <summary>
        /// Открывает приложение.
        /// </summary>
        [CommandMethod("BottleBuilder")]
        public static void OpenApp()
        {
            using (var transction =
                Application.DocumentManager.MdiActiveDocument
                    .Database.TransactionManager.StartTransaction())
            {
                OpenMainForm(transction);
            }
        }

        /// <summary>
        /// Открывает форму для задания параметров.
        /// </summary>
        /// <param name="transaction">Транзакция.</param>
        private static void OpenMainForm(Transaction transaction)
		{
            MainForm mainForm = new MainForm();
            mainForm.CurrentTransaction = transaction;
			mainForm.Show();
		}
	}
}