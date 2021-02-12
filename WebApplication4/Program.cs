using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace WebApplication4
{
	public class Program
	{
		public static void Main(string[] args)
		{
			CreateHostBuilder(args).Build().Run();
			var webHost = new WebHostBuilder()
	   .UseKestrel()
	   .UseContentRoot(Directory.GetCurrentDirectory())
	   .ConfigureAppConfiguration((hostingContext, config) =>
	   {
		   var env = hostingContext.HostingEnvironment;
		   config.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
				 .AddJsonFile($"appsettings.{env.EnvironmentName}.json",
					 optional: true, reloadOnChange: true);
		   config.AddEnvironmentVariables();
	   })
	   .ConfigureLogging((hostingContext, logging) =>
	   {
			// Requires `using Microsoft.Extensions.Logging;`
			logging.AddConfiguration(hostingContext.Configuration.GetSection("Logging"));
		   logging.AddConsole();
		   logging.AddDebug();
		   logging.AddEventSourceLogger();
	   })
	   .UseStartup<Startup>()
	   .Build();

			webHost.Run();
		}

		public static IHostBuilder CreateHostBuilder(string[] args) =>
			Host.CreateDefaultBuilder(args)
				.ConfigureWebHostDefaults(webBuilder =>
				{
					webBuilder.UseStartup<Startup>();
				});

	}
}
