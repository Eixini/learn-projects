using System.Security.Cryptography.X509Certificates;

namespace ReadFromJSONTest;

public class Program
{
	public static void Main(string[] args)
	{
		var builder = WebApplication.CreateBuilder(args);
		var app = builder.Build();

		app.Run(async (context) => 
		{
			var response = context.Response;
			var request = context.Request;
			if (request.Path == "/api/user")
			{
				var message = "Некорректные даные";

				var person = await request.ReadFromJsonAsync<Person>();
				if (person != null)
					message = $"Name: {person.Name} Age: {person.Age}";

				await response.WriteAsJsonAsync(new { text = message});
			}
			else
			{
				response.ContentType = "text/html; charset=utf-8";
				await response.SendFileAsync("html/index.html");
			}
		});

		app.Run();

	}

	public record Person(string Name, int Age);
}