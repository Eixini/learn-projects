namespace UseTest;

public class Program
{
	public static void Main(string[] args)
	{
		var builder = WebApplication.CreateBuilder(args);
		var app = builder.Build();

		string date = "";

		app.Use(async(context,next) => 
		{
			date = DateTime.Now.ToShortDateString();
			await next.Invoke();
			Console.WriteLine($"Current date: {date}");
		});

		app.Run(async(context) => 
		{
			await context.Response.WriteAsync($"Date: {date}");
		});

		app.Run();
	}
}