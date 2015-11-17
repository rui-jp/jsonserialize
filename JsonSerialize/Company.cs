using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonSerialize
{
	public class Company
	{
		public string Name { get; set; }

		private List<Employee> _employments = new List<Employee>();
		public IList<Employee> Employments
		{
			get { return _employments; }
		}

		public void Employ(Employee employment)
		{
			if (!Employments.Contains(employment))
			{
				Employments.Add(employment);
			}
		}
	}
}
