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
			var first = int.Parse(line.Substring(0, line.IndexOf("-")));
			var second = int.Parse(line.Substring(line.IndexOf("-")+1, line.IndexOf(" ")-line.IndexOf("-")-1));
			var c = Convert.ToChar(line.Substring(line.IndexOf(":")-1, 1));
			var pwd = line.Substring(line.IndexOf(":")+2);

			return pwd[first-1] == c ^ pwd[second-1] == c ? 1 : 0;
		}
	}
}
