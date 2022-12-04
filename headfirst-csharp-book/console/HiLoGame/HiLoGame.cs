using System;
using System.Reflection.Metadata.Ecma335;

namespace HiLoGameApp;

internal static class HiLoGame
{
    public const int MAXIMUM = 10;
    private static Random random = new Random();
    private static int currentNumber = random.Next(1, MAXIMUM + 1);
    private static int pot = 10;

    public static void Guess(bool higher)
    {
        int nextNumber = random.Next(1,MAXIMUM + 1);
        if ((higher && (nextNumber >= currentNumber)) || (!higher && (nextNumber <= currentNumber))){
            Console.WriteLine("You guessd right!");
            ++pot;
        }
        else
        {
            Console.WriteLine("Bad luck, you guessed wrong.");
            --pot;
        }
    }

    public static void Hint()
    {
        int half = (int)(MAXIMUM / 2);

        if (pot > 0)
        {
            if (currentNumber > half)
                Console.WriteLine($"The number is at most {half}");
            if (currentNumber < half)
                Console.WriteLine($"The number is at least {half}");
            --pot;
        }
        else
            Console.WriteLine("The pot is empty!");

    }

    public static int GetPot()
    {
        return pot;
    }
}
