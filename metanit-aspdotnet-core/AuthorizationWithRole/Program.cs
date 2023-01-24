using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;

namespace AuthorizationWithRole;

public class Program
{
    public static void Main(string[] args)
    {
        var adminRole = new Role("admin");
        var userRole = new Role("user");
        var people = new List<Person> 
        {
            new Person("tom@gmail.com", "12345", adminRole),
            new Person("bob@gmail.com", "55555", userRole)
        };

        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
               .AddCookie(options =>
               {
                   options.LoginPath = "/login";
                   options.AccessDeniedPath = "/accessdenied";
               });
        builder.Services.AddAuthorization();

        var app = builder.Build();

        app.UseAuthentication();
        app.UseAuthorization();

        app.MapGet("/accessdenied", async (HttpContext context) =>
        {
            context.Response.StatusCode = 403;
            await context.Response.WriteAsync("Access Denied");
        });

        app.MapGet("/login", async (HttpContext context) =>
        {
            context.Response.ContentType = "text/html; charset=utf-8";
            // html-форма для ввода логина/пароля
            string loginForm = @"<!DOCTYPE html>
            <html>
            <head>
                <meta charset='utf-8' />
                <title>METANIT.COM</title>
            </head>
            <body>
                <h2>Login Form</h2>
                <form method='post'>
                    <p>
                        <label>Email</label><br />
                        <input name='email' />
                    </p>
                    <p>
                        <label>Password</label><br />
                        <input type='password' name='password' />
                    </p>
                    <input type='submit' value='Login' />
                </form>
            </body>
            </html>";
            await context.Response.WriteAsync(loginForm);
        });

        app.MapPost("/login", async (string? returnUrl, HttpContext context) =>
        {
            // Получение email и пароль из формы
            var form = context.Request.Form;
            // Если логин и/или пароль не установлены, посылается статусный код ошибки 400
            if (!form.ContainsKey("email") || !form.ContainsKey("password"))
                return Results.BadRequest("E-mail и/или пароль не установлены");
            string email = form["email"];
            string password = form["password"];

            // Поиск пользователя
            Person? person = people.FirstOrDefault(p => p.Email == email && p.Password == password);
            if (person is null)
                return Results.Unauthorized();
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, person.Email),
                new Claim(ClaimsIdentity.DefaultNameClaimType, person.Role.Name)
            };
            var claimsIdentity = new ClaimsIdentity(claims, "Cookies");
            var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

            await context.SignInAsync(claimsPrincipal);

            return Results.Redirect(returnUrl ?? "/");
        });

        // Доступ только для роли admin
        app.Map("/admin", [Authorize(Roles = "admin")]() => "Admin Panel");

        // Доступ только для ролей admin и user
        app.Map("/", [Authorize(Roles = "admin, user")] (HttpContext context) =>
        {
            var login = context.User.FindFirst(ClaimsIdentity.DefaultNameClaimType);
            var role = context.User.FindFirst(ClaimsIdentity.DefaultRoleClaimType);

            return $"Name: {login?.Value}\nRole: {role?.Value}";
        });

        app.MapGet("/logout", async (HttpContext context) =>
        {
            await context.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return "Данные удалены";
        });

        app.Run();
    }
}