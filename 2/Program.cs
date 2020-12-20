using System;
using System.IO;
using System.Linq;

namespace _2
{
	class Program
	{
		static void Main(string[] args)
		{
			var lines = File.ReadAllLines("input.txt");

			int validLines = 0;
			foreach(var line in lines)
			{
				validLines += IsValid(line);
			}
			Console.WriteLine($"Found {validLines} valid lines.");
		}

		static int IsValid(string line)
		{
			var min = int.Parse(line.Substring(0, line.IndexOf("-")));
			var max = int.Parse(line.Substring(line.IndexOf("-")+1, line.IndexOf(" ")-line.IndexOf("-")-1));
			var c = Convert.ToChar(line.Substring(line.IndexOf(":")-1, 1));
			var pwd = line.Substring(line.IndexOf(":")+2);

			var count = pwd.Where(x => x == c).Count();
			return min <= count && count <= max ? 1 : 0;
		}
	}

}
