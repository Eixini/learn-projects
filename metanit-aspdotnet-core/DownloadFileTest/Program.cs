namespace DownloadFileTest;

public class Program
{
	public static void Main(string[] args)
	{
		var builder = WebApplication.CreateBuilder(args);
		var app = builder.Build();

		app.Run(async (context) =>
		{
			context.Response.Headers.ContentDisposition = "attachment; filename=my_image.jpg";
			await context.Response.SendFileAsync("image.jpg");
		});

		app.Run();
	}
}