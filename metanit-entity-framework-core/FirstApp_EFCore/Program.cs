namespace FirstApp_EFCore;

internal class Program
{
    static void Main(string[] args)
    {
        using (ApplicationContext db = new ApplicationContext())
        {
            // Создание двух объектов User
            User tom = new User { Name = "Tom", Age = 33 };
            User alice = new User { Name = "Alice", Age = 26 };

            // Добавление объектов в БД
            db.Users.Add(tom);
            db.Users.Add(alice);
            db.SaveChanges();
            Console.WriteLine("Объекты успешно сохранены!");

            // Получение объектов из БД и вывод на консоль
            var users = db.Users.ToList();
            Console.WriteLine("Список объектов:");
            foreach(User u in users)
                Console.WriteLine($"{u.Id}.{u.Name} - {u.Age}");
        }
    }
}