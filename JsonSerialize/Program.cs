using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonSerialize
{
	class Program
	{
		static void Main(string[] args)
		{
			var suzuki = new Regular() { Name = "Suzuki", Age = 40 };
			var yamada = new PartTimer() { Name = "Yamada", Age = 30, EmploymentPeriod = DateTime.Now };
			var tanaka = new Regular() { Name = "Tanaka", Age = 20 };

			var yucho = new Company() { Name = "Yucho" };
			yucho.Employ(suzuki);
			yucho.Employ(yamada);

			var kanpo = new Company() { Name = "Kampo" };
			kanpo.Employ(yamada);
			kanpo.Employ(tanaka);

			var yuseiGroup = new CompanyGroup();
			yuseiGroup.Companys.Add(yucho);
			yuseiGroup.Companys.Add(kanpo);

			var settings = new JsonSerializerSettings()
			{
				Formatting = Formatting.Indented,
				TypeNameHandling = TypeNameHandling.Auto,
			};

			var json = JsonConvert.SerializeObject(yuseiGroup, settings);
			Console.WriteLine(json);

			var deserialized = JsonConvert.DeserializeObject<CompanyGroup>(json, settings);

			Company company;

			company = deserialized.Companys.FirstOrDefault(x => x.Name == "Yucho");
			if (company != null)
			{
				foreach (var e in company.Employments)
				{
					e.Age++;
					Print(e);
				}
			}

			company = deserialized.Companys.FirstOrDefault(x => x.Name == "Kampo");
			if (company != null)
			{
				foreach (var e in company.Employments)
				{
					e.Age++;
					Print(e);
				}
			}
		}

		private static void Print(Employee e)
		{
			if (e is PartTimer)
			{
				Console.WriteLine("{0}({1}) Period:{2}", e.Name, e.Age, ((PartTimer)e).EmploymentPeriod.ToString());
			}
			else
			{
				Console.WriteLine("{0}({1})", e.Name, e.Age, e.GetType().ToString());
			}
		}
	}
}
