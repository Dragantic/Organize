using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;

namespace Organize {
	class Bitch {
		DirectoryInfo face;
		List<FileInfo> goods;
		List<Bitch> kids = new List<Bitch>();
		Bitch parent;
		int goal=0, from=0, to=0;
		static List<FileInfo> fam;

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

		public static void Burst() {
			fam = new List<FileInfo>();
		}

		void init(DirectoryInfo cute) {
			face = cute;
			var belly = cute.GetDirectories().OrderBy(x =>
				Regex.Replace(x.Name.Replace(",", "").Replace("-", " - "),
					@"\d+", d => d.Value.PadLeft(8, '0'))).ToList();

			foreach (var kid in belly) kids.Add(new Bitch(kid, this));

			goods = cute.GetFiles().Where(x => ext.Contains(x.Extension.ToLower()))
				.OrderBy(x => x.LastWriteTime).ToList();
			if (goods.Count > 0) fam.AddRange(goods);
			if (parent!=null && goods.Count>0)
			{	MatchCollection nums = Regex.Matches
					(face.Name.Replace(",", "").Replace("-", " - "), @"\d+");
				if (nums.Count > 1)
				{	from = Int32.Parse(nums[0].ToString()) - 1;
					to = Int32.Parse(nums[1].ToString());
					goal = to - from;   }   }
			Program.form.nameChange(cute.FullName);
		}

		public void huge() {
			var slags = kids.OrderByDescending(x => x.face.LastWriteTime.AddTicks
				(-1 * (x.face.LastWriteTime.Ticks % TimeSpan.TicksPerSecond))).Reverse();
			bool hard = false;
			for (int i=0; i<kids.Count; i++)
			{	Bitch full = kids[i];
				full.huge();
				Program.form.nameChange(full.face.Name);
				if (!hard && slags.ElementAt(i) == kids[i]) continue;
				else hard = true;
				if (full.goods.Count > 0)
				{	var pump = full.goods[0];
					string swell = pump.Name.Insert(1, " ");
					string gut = pump.Directory.FullName + @"\";
					try
					{	File.Move(gut+pump, gut+swell);
						File.Move(gut+swell, gut+pump);   } catch {}
					Thread.Sleep(1001);   }   }
		}

		public void bloated() {
			fam.Sort((a, b) => DateTime.Compare(a.LastWriteTime, b.LastWriteTime));
			bloating();
			int last = kids.Last().to;
			var kin = fam.GetRange(last, fam.Count-last);
			var gut = kin.Except(goods, new FileInfoEqualityComparer()).ToList();
			try
			{	foreach (var swell in gut)
				{	string round = face.FullName + swell.Name;
					File.Move(swell.FullName, round);   }   } catch {}
		}

		void bloating() {
			for (int grown=0; grown<kids.Count; grown++)
			{	Bitch full = kids[grown];
				full.bloating();
				var kin = fam.GetRange(full.from, full.goal);
				var gut = kin.Except(full.goods, new FileInfoEqualityComparer()).ToList();
				try
				{	foreach (var swell in gut)
					{	string round = full.face.FullName + @"\" + swell.Name;
						File.Move(swell.FullName, round);   }   } catch {}   }
		}
	}

	public class FileInfoEqualityComparer : IEqualityComparer<FileInfo> {
		public bool Equals(FileInfo x, FileInfo y) {
			return x.FullName == y.FullName;
		}

		public int GetHashCode(FileInfo obj) {
			return obj.FullName.GetHashCode();
		}
	}
}
