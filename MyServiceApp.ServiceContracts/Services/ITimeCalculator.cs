using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace MyServiceApp.Services
{
	[ServiceContract]
	public interface ITimeCalculator
	{
		[OperationContract]
		int HoursToMinutes(int amountOfHours);
	}
}