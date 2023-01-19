using Microsoft.EntityFrameworkCore;

namespace WorkWithEntityFrameworkCore;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // ��������� ������ ����������� �� ����� ������������
        string connection = builder.Configuration.GetConnectionString("DefaultConnection");

        // ���������� ��������� ApplicationContext � �������� ������� � ����������
        builder.Services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(connection));

        var app = builder.Build();

        app.MapGet("/", (ApplicationContext db) => db.Users.ToList());

        app.Run();
    }
}