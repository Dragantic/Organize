using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

namespace Organize {
	public partial class frmOrganize : Form {
		public frmOrganize() {
			InitializeComponent();
		}

		private void frmOrganize_Shown(object sender, EventArgs e) {
			nameChange(AppDomain.CurrentDomain.BaseDirectory);
		}

		private void btnModDate_Click(object sender, EventArgs e) {
			btnModDate.Enabled = btnOrganize.Enabled = false;
			Bitch bitch = new Bitch(new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory));
			bitch.pretty();
			btnModDate.Enabled = btnOrganize.Enabled = true;
		}

		private void btnOrganize_Click(object sender, EventArgs e) {
			btnModDate.Enabled = btnOrganize.Enabled = false;
			Bitch bitch = new Bitch(new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory));
			bitch.stacked();
			btnModDate.Enabled = btnOrganize.Enabled = true;
		}

		public void nameChange(string name) {
			lblFolder.Text = name;
		}
	}

	class Bitch {
		DirectoryInfo face;
		List<FileInfo> goods;
		List<Bitch> kids = new List<Bitch>();
		Bitch parent;
		int goal=0;

		static List<string> ext = new List<string>
			{".bmp", ".gif", ".jpg", ".jpeg", ".png", ".swf",
			 ".svg", ".pdf", ".txt", ".avi", ".mp4", ".webm", ".wmv"};

		public Bitch(DirectoryInfo cute) {
			init(cute);
		}

		public Bitch(DirectoryInfo cute, Bitch breeder) {
			parent = breeder;
			init(cute);
		}

		void init(DirectoryInfo cute) {
			face = cute;
			var belly = cute.GetDirectories().OrderBy(x =>
				Regex.Replace(x.Name.Replace(",", "").Replace("-", " - "),
					@"\d+", d => d.Value.PadLeft(8, '0'))).ToList();

			foreach (var kid in belly) kids.Add(new Bitch(kid, this));

			goods = cute.GetFiles().Where(x => ext.Contains(x.Extension.ToLower()))
				.OrderByDescending(x => x.LastWriteTime).ToList();
			if (parent!=null && goods.Count>0)
			{	MatchCollection nums = Regex.Matches
					(face.Name.Replace(",", "").Replace("-", " - "), @"\d+");
				if (nums.Count > 1)
				{	int from = Int32.Parse(nums[0].ToString());
					int to = Int32.Parse(nums[1].ToString());
					goal = to - (from-1);   }   }
			Program.form.nameChange(cute.FullName);
		}

		public void pretty() {
			foreach (Bitch full in kids)
			{	var bloat = full.goods.Count;
				full.pretty();
				Program.form.nameChange(full.face.Name);
				if (bloat > 0)
				{	var pump = full.goods[0];
					string swell = pump.Name.Insert(1, " ");
					string gut = pump.Directory.FullName + @"\";
					try
					{	File.Move(gut+pump, gut+swell);
						File.Move(gut+swell, gut+pump);   } catch {}
					Thread.Sleep(1001);   }   }
		}

		public void stacked() {
			for (int grown=0; grown<kids.Count; grown++)
			{	Bitch full = kids[grown];
				full.stacked();
				string chub = full.face.FullName + @"\";
				int bloat = full.goods.Count;
				int limit = full.goal;
				Program.form.nameChange(full.face.Name);
				if (bloat>0 && bloat!=limit)
				{	Bitch blimped;
					if (grown+1 < kids.Count) { blimped = kids[grown+1]; }
					else if (parent != null)
					{	int p = parent.kids.IndexOf(this);
						blimped = parent.kids[p+1];   }
					else blimped = this;
					var huge = blimped.goods.Count;
					var puff = blimped.face.FullName + @"\";
					if (bloat < limit)
					{	int diff = limit - bloat;
						if (diff > huge) diff = huge;
						var biggins = blimped.goods.GetRange(huge-diff, diff);
						try
						{	foreach (var blimp in biggins)
								File.Move(puff+blimp, chub+blimp);   } catch {}
						blimped.goods.RemoveRange(huge-diff, diff);
						Thread.Sleep(1001);   }
					else if (bloat > limit)
					{	int diff = bloat - limit;
						var biggins = full.goods.GetRange(0, diff);
						try
						{	foreach (var blimp in biggins)
								File.Move(chub+blimp, puff+blimp);   } catch {}
						blimped.goods.AddRange(biggins);
						blimped.goods.Sort((a, b) =>
							DateTime.Compare(b.LastWriteTime, a.LastWriteTime));
						Thread.Sleep(1001);   }   }   }
		}
	}
}
