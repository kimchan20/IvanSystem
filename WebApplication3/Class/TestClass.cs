using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Models;
using WebApplication3.Repository;
namespace WebApplication3.Class
{
	public class TestClass : ITestRepository
	{
		public IEnumerable<indexModel> getallmethods()
		{
			var tolist = new List<indexModel>{
				new indexModel { id="1",age="22",address="1",name="Ivan  Kim"},
				new indexModel { id="2",age="26",address="2",name="Kim"},
				new indexModel { id="3",age="21",address="3",name="Kim Chan"},
			};
			return tolist;
		}

		public indexModel getid(string id)
		{
			return new indexModel { id = "1", age = "2", address = "", name = "Ivan  Kim" };
		}
	}
}
