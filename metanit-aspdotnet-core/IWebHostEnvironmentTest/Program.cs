namespace IWebHostEnvironmentTest;

public class Program
{
	public static void Main(string[] args)
	{
		var builder = WebApplication.CreateBuilder(args);
		var app = builder.Build();

		if (app.Environment.IsDevelopment())
			app.Run(async context => await context.Response.WriteAsync("Is Development Stage"));
		else
			app.Run(async context => await context.Response.WriteAsync("Is Production Stage"));
		Console.WriteLine($"{app.Environment.EnvironmentName}");

		app.Run();
	}
}