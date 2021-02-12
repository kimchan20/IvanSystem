using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace TestCore.Controller
{
	public class HomeController : Controller
	{
		public IActionResult Index()
		{
			return Ok();
		}
	}
}
