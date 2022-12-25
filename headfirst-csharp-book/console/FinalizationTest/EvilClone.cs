namespace FinalizationTest;

internal class EvilClone
{
    public static int CloneCount = 0;
    public int CloneID { get; } = ++CloneCount;

    public EvilClone() => Console.WriteLine($"Clone {CloneID} is wreaking havoc");
    ~EvilClone() => Console.WriteLine($"Clone #{CloneID} destroyed");
}
