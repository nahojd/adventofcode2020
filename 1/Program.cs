using System;
using System.IO;
using System.Linq;
using Spectre.Console;

namespace _1
{
	class Program
	{
		static void Main(string[] args)
		{
			//List of numbers
			var numbers = File.ReadAllLines("input.txt").Select(x => int.Parse(x)).ToList();

			AnsiConsole.Progress()
				.Start(ctx => {
					var task1 = ctx.AddTask("[yellow]Computing sums[/]");
					task1.MaxValue = numbers.Count;
					task1.StartTask();
					task1.Increment(1);

					int number1 = -1;
					int number2 = -1;

					for (var i=1; i<numbers.Count; i++)
					{
						task1.Increment(1);

						for (var j=0; j<i; j++) {
							if (numbers[i] + numbers[j] == 2020)
							{
								number1 = numbers[i];
								number2 = numbers[j];
								break;
							}
						}

						if (number1 >= 0)
							break;
					}

					task1.StopTask();

					AnsiConsole.MarkupLine($"[green]{number1} * {number2} = {number1*number2}[/]");
				});
		}
	}
}
