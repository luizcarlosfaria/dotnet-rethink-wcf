using MyServiceApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace WcfClientConsole
{
	class Program
	{
		static void Main()
		{
			Console.Write("Aguardando inicialização do host WCF");
			for (var i = 0; i < 3; i++)
			{
				System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
				Console.Write(".");
			}
			Console.WriteLine(string.Empty);

			Log("Criando clientes NET TCP e HTTP");
			ITimeCalculator[] timeCalculators = new ITimeCalculator[] {
				new ChannelFactory<ITimeCalculator>("tcp").CreateChannel() ,
				new ChannelFactory<ITimeCalculator>("http").CreateChannel()
			};

			Log("Consumindo...");
			foreach (var timeCalculator in timeCalculators)
			{
				int seconds = timeCalculator.HoursToMinutes(12);
				Log($"Teste 120 > ${seconds}", ConsoleColor.Red);
				((ICommunicationObject)timeCalculator).Close();
			}
			Log("Finalizado, pressione qualquer tecla para encerrar o processo.");
			Console.ReadKey();
		}

		private static void Log(string text, ConsoleColor? consoleColor = null)
		{
			if (consoleColor != null)
			{
				var oldColor = Console.ForegroundColor;
				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine(text);
				Console.ForegroundColor = oldColor;
			}
			else
				Console.WriteLine(text);
		}
	}
}
