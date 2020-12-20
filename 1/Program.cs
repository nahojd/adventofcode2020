using System;
using System.Collections.Generic;
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

					var (number1, number2, number3) = FindNumbers(numbers, task1);

					task1.StopTask();

					AnsiConsole.MarkupLine($"[green]{number1} * {number2} * {number3} = {number1*number2*number3}[/]");
				});
		}

		static (int,int,int) FindNumbers(List<int> numbers, ProgressTask task1)
		{
			for (var i=0; i<numbers.Count; i++)
			{
				task1.Increment(1);

				for (var j=0; j<numbers.Count; j++)
				{
					if (j==i)
						continue;

					for (var k=0; k<numbers.Count; k++)
					{
						if (k==i || k==j)
							continue;

						if (numbers[i] + numbers[j] + numbers[k] == 2020)
						{
							return (numbers[i], numbers[j], numbers[k]);
						}
					}
				}
			}

			throw new Exception("Now, this was unexpected!");
		}
	}
}
