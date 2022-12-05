using System;

namespace Paintball;

internal class PaintballGun
{

    private int balls = 0;

    public PaintballGun(int balls, int magazineSize, bool loaded)
    {
        this.balls = balls;
        MagazineSize= magazineSize;
        if (!loaded) Reload();
    }

    public int Balls
    {
        get { return balls; }
        set {
            if (value > 0)
                balls = value;
            Reload();
        }
    }

    public int MagazineSize { get; private set; } = 16;

    public int  BallsLoaded { get; private set; }

    public static int ReadInt(int intValue, string message)
    {
        Console.WriteLine($"{message} [{intValue}]");
        string line = Console.ReadLine();
        if(int.TryParse(line, out int value))
        {
            Console.WriteLine($" using value {value}");
            return value;
        }
        else
        {
            Console.WriteLine($" using default value {intValue}");
            return intValue;
        }
    }

    public bool IsEmpty()
    {
        return BallsLoaded == 0;
    }

    public void Reload()
    {
        if (balls > MagazineSize)
            BallsLoaded = MagazineSize;
        else
            BallsLoaded = balls;
    }

    public bool Shoot()
    {
        if (BallsLoaded == 0)
            return false;
        BallsLoaded--;
        balls--;
        return true;
    }
}
