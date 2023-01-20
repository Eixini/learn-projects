using Microsoft.EntityFrameworkCore;

namespace WorkWithEntityFrameworkCore_2;

public class ApplicationContext : DbContext
{
    public DbSet<User> Users { get; set; } = null!;
    public ApplicationContext(DbContextOptions<ApplicationContext> options)
        : base(options)
    {
        Database.EnsureCreated();   // Создание БД при первом обращении
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().HasData(
            new User { Id = 1, Name = "Tom", Age = 37 },
            new User { Id = 2, Name = "Bob", Age = 41 },
            new User { Id = 3, Name = "Sam", Age = 24 }
            );
    }
}
