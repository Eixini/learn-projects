namespace RedirectTest
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);
			var app = builder.Build();

			app.Run(async (context) =>
			{
				if (context.Request.Path == "/old")
				{
					context.Response.Redirect("/new");
				}
				else if (context.Request.Path == "/new")
				{
					await context.Response.WriteAsync("New Page");
				}
				else
				{
					await context.Response.WriteAsync("Main Page");
				}
			});

			app.Run();
		}
	}
}