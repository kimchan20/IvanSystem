using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication3.Class;
using WebApplication3.Models;
z`
namespace WebApplication3.Controllers
{
	[ApiController]
	public class IndexController : ControllerBase
	{
		private readonly TestClass testclass = new TestClass();	


		[HttpGet]
		public ActionResult <IEnumerable<indexModel>> GetResult()
		{
		}

		[HttpGet]
		public ActionResult <indexModel> getindexresult(int id)
		{

		}
	}
}
