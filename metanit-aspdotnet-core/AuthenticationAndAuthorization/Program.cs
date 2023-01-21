using Microsoft.AspNetCore.Authorization;

namespace AuthenticationAndAuthorization;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // ���������� ������� ��������������
        builder.Services.AddAuthentication("Bearer").AddJwtBearer();
        // ���������� �������� ����������
        builder.Services.AddAuthorization();

        var app = builder.Build();

        app.UseAuthentication();    // ���������� middleware ��������������
        app.UseAuthorization();     // ���������� middleware �����������

        app.MapGet("/hello", [Authorize]() => "Hello!");
        app.MapGet("/", () => "Home page");

        app.Run();
    }
}