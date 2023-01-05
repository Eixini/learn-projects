namespace UseWhenTest;

public class Program
{
	public static void Main(string[] args)
	{
		var builder = WebApplication.CreateBuilder(args);
		var app = builder.Build();

		app.UseWhen(
			context => context.Request.Path == "/time",	// Если путь запроса "/time"
			appBuilder =>
			{
				// Логгируем данные - выводим на консоль приложения
				appBuilder.Use(async (context,next) => 
				{
					var time = DateTime.Now.ToShortTimeString();
					Console.WriteLine($"Time: {time}");
					await next(); // Вызываем следующий middleware
				});
				// Отправляем ответ
				appBuilder.Run(async context => 
				{
					var time = DateTime.Now.ToShortTimeString();
					await context.Response.WriteAsync(time);
				});
			});

		app.Run(async context => 
		{
			await context.Response.WriteAsync("Hello!");
		});

		app.Run();
	}
}