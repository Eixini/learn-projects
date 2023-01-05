using System.Text;

namespace ServicesTest;

public class Program
{
	public static void Main(string[] args)
	{
		var builder = WebApplication.CreateBuilder(args);
		var services = builder.Services;
		var app = builder.Build();

		app.Run(async context => 
		{
			var stringBuilder = new StringBuilder();
			stringBuilder.Append("<h1>Все сервисы</h1>");
			stringBuilder.Append("<table>");
			stringBuilder.Append("<tr><th>Тип</th><th>Lifetime</th><th>Реализация</th></tr>");
			foreach (var service in services)
			{
				stringBuilder.Append("<tr>");
				stringBuilder.Append($"<td>{service.ServiceType.FullName}</td>");
				stringBuilder.Append($"<td>{service.Lifetime}</td>");
				stringBuilder.Append($"<td>{service.ImplementationType?.FullName}</td>");
				stringBuilder.Append("</tr>");
			}
			stringBuilder.Append("</table>");
			context.Response.ContentType = "text/html;charset=utf-8";
			await context.Response.WriteAsync(stringBuilder.ToString());
		});

		app.Run();
	}
}