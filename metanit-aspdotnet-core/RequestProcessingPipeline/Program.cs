namespace RequestProcessingPipeline;

public class Program
{
	public static void Main(string[] args)
	{
		var builder = WebApplication.CreateBuilder(args);
		var app = builder.Build();

		app.UseMiddleware<ErrorHandlingMiddleware>();
		app.UseMiddleware<AuthenticationMiddleware>();
		app.UseMiddleware<RoutingMiddleware>();

		app.Run();
	}
}