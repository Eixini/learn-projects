namespace TestRandom;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Test Random class." + '\n');

        Random random = new Random();
        int randomInt = random.Next();
        Console.WriteLine($"Random int = {randomInt}" + '\n');

        int zeroToNine = random.Next(10);
        Console.WriteLine($"Random [0;9] = {zeroToNine}" + '\n');

        int dieRoll = random.Next(1, 7);
        Console.WriteLine($"Roll = {dieRoll}" + '\n');

        double randomDouble = random.NextDouble();
        Console.WriteLine($"Random double (x100) = {randomDouble * 100}");
        Console.WriteLine($"Random double (to float) (x100) = {(float)randomDouble * 100F}");
        Console.WriteLine($"Random double (to decimal) (x100) = {(decimal)randomDouble * 100M}" + '\n');

        int zeroOrOne = random.Next(2);
        bool coinFlip = Convert.ToBoolean(zeroOrOne);
        Console.WriteLine($"Coin flip = {coinFlip}");
    }
}