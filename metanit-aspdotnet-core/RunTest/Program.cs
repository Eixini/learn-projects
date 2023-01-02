namespace RunTest;

public class Program
{
	public static void Main(string[] args)
	{
		var builder = WebApplication.CreateBuilder(args);
		var app = builder.Build();

		int x = 2;

		app.Run(async (context) =>
		{
			x *= 2;
			await context.Response.WriteAsync($"Result: {x}");
		});

		app.Run();
	}
}