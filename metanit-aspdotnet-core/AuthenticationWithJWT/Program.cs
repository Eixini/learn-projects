using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AuthenticationWithJWT;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddAuthorization();
        builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    // Указывает, будет ли валидироваться издатель при валидации токена
                    ValidateIssuer = true,
                    // Строка, представляющая издателя
                    ValidIssuer = AuthOptions.ISSUER,
                    // Будет ли валидироваться потребитель токена
                    ValidateAudience = true,
                    // Установка потребителя токена
                    ValidAudience = AuthOptions.AUDIENCE,
                    // Будет ли валидироваться время существования
                    ValidateLifetime = true,
                    // Установка ключа безопасности
                    IssuerSigningKey = AuthOptions.GetSymmetricSecurity(),
                    // Валидация ключа безопасности
                    ValidateIssuerSigningKey = true
                };
            });

        var app = builder.Build();

        app.UseAuthentication();    // Добавление middleware аутентификации
        app.UseAuthorization();     // Добавление middleware авторизации

        app.MapGet("/login/{username}", (string username) => 
        {
            var claims = new List<Claim> { new Claim(ClaimTypes.Name, username)};
            // Создание JWT-токена
            var jwt = new JwtSecurityToken(
                issuer: AuthOptions.ISSUER,
                audience: AuthOptions.AUDIENCE,
                claims: claims,
                expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(2)),
                signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurity(),
                                                           SecurityAlgorithms.HmacSha256)
                );

            return new JwtSecurityTokenHandler().WriteToken(jwt);
        });

        app.Map("/data", [Authorize] () => new { message = "Hello world!" });

        app.Run();
    }

    public class AuthOptions
    {
        public const string ISSUER = "MyAuthServer";         // Издатель токена
        public const string AUDIENCE = "MyAuthClient";       // Потребитель токена
        const string KEY = "mysupersecret_secretkey!123";    // Ключ для шифрации

        public static SymmetricSecurityKey GetSymmetricSecurity() =>
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(KEY));
    }
}