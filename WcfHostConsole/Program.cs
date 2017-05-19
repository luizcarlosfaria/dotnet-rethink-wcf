using MyServiceApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;


namespace WcfHostConsole
{
	class Program
	{
		static void Main()
		{
			Console.WriteLine("Inicializando Host WCF");

			Type[] services = new Type[] { typeof(TimeCalculatorService) };

			ServiceHost[] hosts = services.Select(srcType =>
			{
				var serviceHost = new ServiceHost(srcType);
				Console.WriteLine($"Inicializando ${srcType.ToString()}...");
				serviceHost.Open();
				Console.WriteLine($"Inicializado");
				return serviceHost;
			}).ToArray();

			Console.WriteLine($"Aguardando conexões! (Pressione qualquer tecla para finalizar)");
			Console.ReadKey();
			Console.WriteLine($"Encerrando pipeline...");
			var reverseList = new List<ServiceHost>(hosts);
			reverseList.Reverse();
			reverseList.ForEach(it => it.Close());
			Console.WriteLine($"Pipeline finalizado");
			Console.WriteLine(string.Empty);
			Console.ReadKey();
		}
	}
}
