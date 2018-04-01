using System;
using System.Windows.Forms;

namespace Organize {
	static class Program {
		public static frmOrganize form;

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() {
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);

			form = new frmOrganize();
			Application.Run(form);
		}
	}
}
