namespace Paintball;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcom to Paintball!" + '\n');

        int numberOfBalls = PaintballGun.ReadInt(20, "Number of balls");
        int magazineSize = PaintballGun.ReadInt(16, "Magazine size");

        Console.WriteLine($"Loaded [false]: ");
        bool.TryParse(Console.ReadLine(),out bool isLoaded);

        PaintballGun gun = new PaintballGun(numberOfBalls, magazineSize, isLoaded);

        while (true)
        {
            Console.WriteLine($"{gun.Balls} balls, {gun.BallsLoaded} loaded.");
            if (gun.IsEmpty())
            {
                Console.ForegroundColor = ConsoleColor.Red;             // Немножко отсебятины
                Console.WriteLine("WARNING: You're out of ammo!");
                Console.ResetColor();
            }
            Console.WriteLine("Space to shoot, r to reloaded, + tp add ammo, q to quit.");
            char key = Console.ReadKey(true).KeyChar;
            if (key == ' ')
                Console.WriteLine($"Shooting returned {gun.Shoot()}");
            else if (key == 'r')
                gun.Reload();
            else if (key == '+')
                gun.Balls += gun.MagazineSize;
            else if (key == 'q')
                return;
        }
    }
}