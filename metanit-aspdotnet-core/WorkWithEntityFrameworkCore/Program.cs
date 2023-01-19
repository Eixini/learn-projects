using Microsoft.EntityFrameworkCore;

namespace WorkWithEntityFrameworkCore;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Получение строки подключения из файла конфигурации
        string connection = builder.Configuration.GetConnectionString("DefaultConnection");

        // Добавление контекста ApplicationContext в качестве сервиса в приложении
        builder.Services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(connection));

        var app = builder.Build();

        app.MapGet("/", (ApplicationContext db) => db.Users.ToList());

        app.Run();
    }
}