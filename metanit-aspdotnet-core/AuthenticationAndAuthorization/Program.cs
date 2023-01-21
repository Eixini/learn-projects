using Microsoft.AspNetCore.Authorization;

namespace AuthenticationAndAuthorization;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Добавление сервиса аутентификации
        builder.Services.AddAuthentication("Bearer").AddJwtBearer();
        // Добавление сервисов авторизаци
        builder.Services.AddAuthorization();

        var app = builder.Build();

        app.UseAuthentication();    // Добавление middleware аутентификации
        app.UseAuthorization();     // Добавление middleware авторизации

        app.MapGet("/hello", [Authorize]() => "Hello!");
        app.MapGet("/", () => "Home page");

        app.Run();
    }
}