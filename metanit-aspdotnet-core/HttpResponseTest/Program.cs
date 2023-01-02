namespace HttpResponseTest;

public class Program
{
	public static void Main(string[] args)
	{
		var builder = WebApplication.CreateBuilder(args);
		var app = builder.Build();

		app.Run(async (context) =>
		{
			var response = context.Response;

			response.ContentType = "text/html; charset=utf-8";
			await response.WriteAsync("<h2>Hello!</h2><h3>Welcome to ASP.NET Core</h3>");
		});

		app.Run();
	}
}