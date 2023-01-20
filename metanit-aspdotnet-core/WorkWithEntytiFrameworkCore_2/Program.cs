using Microsoft.EntityFrameworkCore;
using WorkWithEntityFrameworkCore_2;

namespace WorkWithEntytiFrameworkCore_2;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        string connection = builder.Configuration.GetConnectionString("DefaultConnection");
        builder.Services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(connection));

        var app = builder.Build();

        app.UseDefaultFiles();
        app.UseStaticFiles();

        app.MapGet("/api/users", async (ApplicationContext db) => await db.Users.ToListAsync());

        app.MapGet("/api/users/{id:int}", async (int id, ApplicationContext db) =>
        {
            // Получение пользователя по ID
            User? user = await db.Users.FirstOrDefaultAsync(u => u.Id == id);

            // Если пользователь не найден, отправляется статусный код и сообщение об ошибке
            if (user == null)
                return Results.NotFound(new { message = "Пользователь не найден" });

            // Если пользователь найден, отправляем его
            return Results.Json(user);
        });

        app.MapDelete("/api/users", async (int id, ApplicationContext db) =>
        {
            // Получение пользователя по ID
            User? user = await db.Users.FirstOrDefaultAsync(u => u.Id == id);

            // Если пользователь не найден, отправляется статусный код об ошибке
            if (user == null)
                return Results.NotFound(new { message = "Пользователь не найден" });

            // Если пользователь найден, происходит его удаление
            db.Users.Remove(user);
            await db.SaveChangesAsync();
            return Results.Json(user);
        });

        app.MapPost("/api/users", async (User user, ApplicationContext db) =>
        {
            // Добавление пользователя в массив
            await db.Users.AddAsync(user);
            await db.SaveChangesAsync();
            return user;
        });

        app.MapPut("/api/users", async (User userData, ApplicationContext db) =>
        {
            // Получение пользователя по ID
            var user = await db.Users.FirstOrDefaultAsync(u => u.Id == userData.Id);

            // Если пользователь найден, отправляется статусный код и сообщение об ошибке
            if (user == null)
                return Results.NotFound(new { message = "Пользователь не найден" });

            // Если пользователь найден, происходит изменение его данных и отправка обратно клиенту
            user.Age = userData.Age;
            user.Name = userData.Name;
            await db.SaveChangesAsync();
            return Results.Json(user);
        });

        app.Run();
    }
}