using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;

namespace ClaimObjectTest;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
               .AddCookie();

        var app = builder.Build();

        app.UseAuthentication();

        app.MapGet("/login", async (HttpContext context) =>
        {
            var username = "Tom";
            var company = "Microsoft";
            var phone = "+12345678901";

            var claims = new List<Claim>
            {
                new Claim (ClaimTypes.Name, username),
                new Claim("company", company),
                new Claim(ClaimTypes.MobilePhone, phone)
            };

            var claimsIdentity = new ClaimsIdentity(claims, "Cookies");
            var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

            await context.SignInAsync(claimsPrincipal);

            return Results.Redirect("/");
        });

        app.Map("/", (HttpContext context) =>
        {
            var username = context.User.FindFirst(ClaimTypes.Name);
            var phone = context.User.FindFirst(ClaimTypes.MobilePhone);
            var company = context.User.FindFirst("company");

            return $"Name: {username?.Value}\nPhone: {phone?.Value}\nCompany: {company?.Value}";
        });

        app.MapGet("/logout", async (HttpContext context) =>
        {
            await context.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return "Данные удалены";
        });

        app.Run();
    }
}