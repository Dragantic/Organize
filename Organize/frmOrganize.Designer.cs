namespace Organize {
	partial class frmOrganize {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.btnModDate = new System.Windows.Forms.Button();
			this.btnOrganize = new System.Windows.Forms.Button();
			this.lblFolder = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// btnModDate
			// 
			this.btnModDate.Location = new System.Drawing.Point(12, 22);
			this.btnModDate.Name = "btnModDate";
			this.btnModDate.Size = new System.Drawing.Size(75, 72);
			this.btnModDate.TabIndex = 0;
			this.btnModDate.Text = "Refresh ModDates";
			this.btnModDate.UseVisualStyleBackColor = true;
			this.btnModDate.Click += new System.EventHandler(this.btnModDate_Click);
			// 
			// btnOrganize
			// 
			this.btnOrganize.Location = new System.Drawing.Point(167, 22);
			this.btnOrganize.Name = "btnOrganize";
			this.btnOrganize.Size = new System.Drawing.Size(75, 72);
			this.btnOrganize.TabIndex = 1;
			this.btnOrganize.Text = "Organize Images";
			this.btnOrganize.UseVisualStyleBackColor = true;
			this.btnOrganize.Click += new System.EventHandler(this.btnOrganize_Click);
			// 
			// lblFolder
			// 
			this.lblFolder.AutoSize = true;
			this.lblFolder.Location = new System.Drawing.Point(12, 97);
			this.lblFolder.Name = "lblFolder";
			this.lblFolder.Size = new System.Drawing.Size(0, 13);
			this.lblFolder.TabIndex = 2;
			// 
			// frmOrganize
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(254, 115);
			this.Controls.Add(this.lblFolder);
			this.Controls.Add(this.btnOrganize);
			this.Controls.Add(this.btnModDate);
			this.Name = "frmOrganize";
			this.Text = "Organize";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmOrganize_FormClosing);
			this.Load += new System.EventHandler(this.frmOrganize_Load);
			this.Shown += new System.EventHandler(this.frmOrganize_Shown);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btnModDate;
		private System.Windows.Forms.Button btnOrganize;
		private System.Windows.Forms.Label lblFolder;
	}
}

