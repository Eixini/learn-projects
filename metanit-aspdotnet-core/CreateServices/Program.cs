namespace CreateServices;

public class Program
{
	public static void Main(string[] args)
	{
		var builder = WebApplication.CreateBuilder(args);
		builder.Services.AddTransient<ITimeService, ShortTimeServices>();
		var app = builder.Build();

		app.Run(async context => 
		{
			var timeService = app.Services.GetService<ITimeService>();
			await context.Response.WriteAsync($"Time: {timeService?.GetTime()}");
		});

		app.Run();
	}
}