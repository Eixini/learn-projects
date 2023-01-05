namespace MiddlewareClasses;

public class Program
{
	public static void Main(string[] args)
	{
		var builder = WebApplication.CreateBuilder(args);
		var app = builder.Build();

		app.UseToken("1234");

		app.Run(async context => await context.Response.WriteAsync("Hello!"));

		app.Run();
	}
}