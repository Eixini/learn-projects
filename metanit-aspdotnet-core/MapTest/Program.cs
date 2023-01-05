namespace MapTest;

public class Program
{
	public static void Main(string[] args)
	{
		var builder = WebApplication.CreateBuilder();
		var app = builder.Build();

		app.Map("/home", appBuilder =>
		{
			appBuilder.Map("/index", Index); // middleware для "/home/index"
			appBuilder.Map("/about", About); // middleware для "/home/about"
											 // middleware для "/home"
			appBuilder.Run(async (context) => await context.Response.WriteAsync("Home Page"));
		});

		app.Run(async (context) => await context.Response.WriteAsync("Page Not Found"));

		app.Run();

		void Index(IApplicationBuilder appBuilder)
		{
			appBuilder.Run(async context => await context.Response.WriteAsync("Index Page"));
		}
		void About(IApplicationBuilder appBuilder)
		{
			appBuilder.Run(async context => await context.Response.WriteAsync("About Page"));
		}
	}
}