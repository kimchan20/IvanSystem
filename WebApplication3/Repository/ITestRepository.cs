using System.Collections.Generic;
using WebApplication3.Models;

namespace WebApplication3.Repository
{
	public interface ITestRepository
	{
		IEnumerable<indexModel> getallmethods ();
		indexModel getid (string id);
	}
}
