namespace SequenceImpl;

internal class Program
{
    static void Main(string[] args)
    {
        // #1
        var sports = new ManualSportSequence();
        foreach(var sport in sports)
            Console.WriteLine(sport);
    }
}