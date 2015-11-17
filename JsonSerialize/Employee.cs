using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonSerialize
{
	[JsonObject(IsReference = true)]
	public class Employee
	{
		public string Name { get; set; }

		public int Age { get; set; }
	}
}
