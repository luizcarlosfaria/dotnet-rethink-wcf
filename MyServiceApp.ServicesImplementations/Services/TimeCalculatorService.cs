using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyServiceApp.Services
{
	public class TimeCalculatorService : ITimeCalculator
	{
		public int HoursToMinutes(int amountOfHours)
		{
			Log("Requisição Recebida!");
			return amountOfHours * 60;
		}

		private static void Log(string text)
		{
			var oldColor = Console.ForegroundColor; 
			Console.ForegroundColor = ConsoleColor.Red; 
			Console.WriteLine(text); 
			Console.ForegroundColor = oldColor;
		}
	}
}
