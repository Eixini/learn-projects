namespace SendFileTest;

public class Program
{
	public static void Main(string[] args)
	{
		var builder = WebApplication.CreateBuilder(args);
		var app = builder.Build();

		app.Run(async (context) =>
		{
			var path = context.Request.Path;
			if (path == "/images/image1.jpg")
				await context.Response.SendFileAsync($"images{Path.DirectorySeparatorChar}image1.jpg");
			else if (path == "/welcome") {
				context.Response.ContentType= "text/html; charset=utf-8";
				await context.Response.SendFileAsync($"pages{Path.DirectorySeparatorChar}index.html");
			}
			else
				await context.Response.WriteAsync("Hello!");
		});

		app.Run();
	}
}