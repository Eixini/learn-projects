namespace LambdaTest;

internal class Program
{
    static Random random => new Random();

    static double GetRandomDouble(int max) => max * random.NextDouble();

    static void PrintValue(double d) => Console.WriteLine($"The value is {d:0.0000}");

    static void Main(string[] args)
    {
        //Test #1
        var value = Program.GetRandomDouble(100);
        Program.PrintValue(value);
        Console.WriteLine();

        //Test #2
        int[] values = new int[] { 0, 12, 44, 36, 92, 54, 13, 8};
        var result = values.Where(v => v < 37).OrderByDescending(v => v).Select(v => v * 2); ;

        foreach (var res in result)
            Console.Write($"{res} ");
        Console.WriteLine();
    }
}