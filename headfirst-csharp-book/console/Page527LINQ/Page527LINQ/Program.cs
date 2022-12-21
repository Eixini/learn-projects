using Page527LINQ;

public class Program
{
    public static void Main(string[] args)
    {
        var lsitOfObjects = new List<PrintWhenGetting>();
        for (int i = 1; i < 5; i++)
            lsitOfObjects.Add(new PrintWhenGetting() {InstanceNumber = i});
        Console.WriteLine("Set up the query");
        var result =
            from o in lsitOfObjects
            select o.InstanceNumber;
        var immediate = result.ToList();
        Console.WriteLine("Run the foreach");
        foreach(var number in immediate)
            Console.WriteLine($"Writing #{number}");
    }
}