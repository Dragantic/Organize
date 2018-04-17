using Organize.Properties;
using System;
using System.IO;
using System.Windows.Forms;

namespace Organize {
	public partial class frmOrganize : Form {
		public frmOrganize() {
			InitializeComponent();
		}

		private void frmOrganize_Load(object sender, EventArgs e) {
			Location = Settings.Default.Location;
		}

		private void frmOrganize_FormClosing(object sender, FormClosingEventArgs e) {
			Settings.Default.Location = Location;
			Settings.Default.Save();
		}

		private void frmOrganize_Shown(object sender, EventArgs e) {
			lblFolder.Text = AppDomain.CurrentDomain.BaseDirectory;
		}

		public void nameChange(string name) {
			lblFolder.Text = name;
		}

		private void btnModDate_Click(object sender, EventArgs e) {
			btnModDate.Enabled = btnOrganize.Enabled = false;
			Bitch.Burst();
			Bitch bitch = new Bitch(new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory));
			bitch.huge();
			btnModDate.Enabled = btnOrganize.Enabled = true;
		}

		private void btnOrganize_Click(object sender, EventArgs e) {
			btnModDate.Enabled = btnOrganize.Enabled = false;
			Bitch.Burst();
			Bitch bitch = new Bitch(new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory));
			bitch.bloated();
			Bitch.Burst();
			bitch = new Bitch(new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory));
			bitch.huge();
			btnModDate.Enabled = btnOrganize.Enabled = true;
		}
	}
}
