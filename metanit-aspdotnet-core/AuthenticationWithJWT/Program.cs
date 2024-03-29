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
                    // ���������, ����� �� �������������� �������� ��� ��������� ������
                    ValidateIssuer = true,
                    // ������, �������������� ��������
                    ValidIssuer = AuthOptions.ISSUER,
                    // ����� �� �������������� ����������� ������
                    ValidateAudience = true,
                    // ��������� ����������� ������
                    ValidAudience = AuthOptions.AUDIENCE,
                    // ����� �� �������������� ����� �������������
                    ValidateLifetime = true,
                    // ��������� ����� ������������
                    IssuerSigningKey = AuthOptions.GetSymmetricSecurity(),
                    // ��������� ����� ������������
                    ValidateIssuerSigningKey = true
                };
            });

        var app = builder.Build();

        app.UseAuthentication();    // ���������� middleware ��������������
        app.UseAuthorization();     // ���������� middleware �����������

        app.MapGet("/login/{username}", (string username) => 
        {
            var claims = new List<Claim> { new Claim(ClaimTypes.Name, username)};
            // �������� JWT-������
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
        public const string ISSUER = "MyAuthServer";         // �������� ������
        public const string AUDIENCE = "MyAuthClient";       // ����������� ������
        const string KEY = "mysupersecret_secretkey!123";    // ���� ��� ��������

        public static SymmetricSecurityKey GetSymmetricSecurity() =>
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(KEY));
    }
}