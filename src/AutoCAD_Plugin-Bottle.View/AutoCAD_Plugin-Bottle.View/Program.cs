namespace AutoCAD_Plugin_Bottle.View
{
	using System;
	using System.Windows.Forms;

    /// <summary>
    /// Программа, запускающая приложение.
    /// </summary>
    public static class Program
    {
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		private static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new MainForm());
		}
	}
}
