namespace UploadFileToServer;

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

			response.ContentType = "text/html; charset=utf-8";

			if (request.Path == "/upload" && request.Method == "POST")
			{
				IFormFileCollection files = request.Form.Files;
				// Путь к папке, где будут храниться файлы
				var uploadPath = $"{Directory.GetCurrentDirectory()}/uploads";
				// Создание папки для хранения файлов
				Directory.CreateDirectory(uploadPath);

				foreach(var file in files)
				{
					// Путь к папке uploads
					string fullPath = $"{uploadPath}/{file.FileName}";
					// Сохранение файла в папку upload
					using (var fileStream = new FileStream(fullPath, FileMode.Create))
					{
						await file.CopyToAsync(fileStream);
					}
				}
				await response.WriteAsync("Файлы успешно загружены");
			}
			else
			{
				await response.SendFileAsync("html/index.html");
			}
			
		});

		app.Run();
	}
}