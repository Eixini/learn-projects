namespace AbilityScoreTester;

public class AbilityScoreCalculator
{
    public int RollResult = 14;
    public double DivideBy = 1.75;
    public int AddAmount = 2;
    public int Minimum = 3;
    public int Score;

    public void CalculateAbilityScore()
    {
        // Результат броска делится на значение поля DivideBy
        double divided = RollResult / DivideBy;

        // AddAmount прибавляется к результату деления
        int added = AddAmount + (int)divided;

        // Если результат слишком мал, использовать значение Minimum
        if (added < Minimum)
            Score = Minimum;
        else
            Score = added;
    }

    /// <summary>
    /// Выводит сообщение и читает значнеие int консоли.
    /// </summary>
    /// <param name="lastUsedValue">Значение по умолчанию.</param>
    /// <param name="prompt">Сообщение, выводимое на консоль.</param>
    /// <returns>
    /// Прочитанное значение int или значение по умолчанию, если преобразование невозможно.
    /// </returns>
    public static int ReadInt(int lastUsedValue, string prompt)
    {
        Console.WriteLine($"{prompt}[{lastUsedValue}]:");
        string readString = Console.ReadLine();
        if (int.TryParse(readString, out int value))
        {
            Console.WriteLine($" using value {value}");
            return value;
        }
        else
        {
            Console.WriteLine($" using default value {lastUsedValue}");
            return lastUsedValue;
        }


    }

    /// <summary>
    /// Выводит сообщение и читает значнеие double консоли.
    /// </summary>
    /// <param name="lastUsedValue">Значение по умолчанию.</param>
    /// <param name="prompt">Сообщение, выводимое на консоль.</param>
    /// <returns>
    /// Прочитанное значение double или значение по умолчанию, если преобразование невозможно.
    /// </returns>
    public static double ReadDouble(double lastUsedValue, string prompt)
    {
        Console.WriteLine($"{prompt}[{lastUsedValue}]:");
        string readString = Console.ReadLine();
        if (double.TryParse(readString, out double value))
        {
            Console.WriteLine($" using value {value}");
            return value;
        }
        else
        {
            Console.WriteLine($" using default value {lastUsedValue}");
            return lastUsedValue;
        }
    }
}