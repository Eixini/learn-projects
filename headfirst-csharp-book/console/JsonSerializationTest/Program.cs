using System.Text.Json;

namespace JSONserializationTest;

internal class Program
{
    static void Main(string[] args)
    {
        var guys = new List<Guy>()
        {
            new Guy()
            {
                Name = "Bob",
                Clothes = new Outfit()
                {
                    Top = "t-shirt",
                    Bottom = "jeans"
                },
                Hair = new HairStyle()
                {
                    Color = HairColor.Red,
                    Length = 3.5f
                }
            },
            new Guy()
            {
                Name = "Joe",
                Clothes = new Outfit()
                {
                    Top = "polo",
                    Bottom = "slacks"
                },
                Hair = new HairStyle()
                {
                    Color = HairColor.Gray,
                    Length = 2.7f
                }
            }
        };

        var options = new JsonSerializerOptions() { WriteIndented = true };
        var jsonString = JsonSerializer.Serialize(guys, options);
        Console.WriteLine("============ Serialize ===========");
        Console.WriteLine(jsonString);
        Console.WriteLine("============ Deserialize ===========");
        var copyOfGuys = JsonSerializer.Deserialize<List<Guy>>(jsonString);
        foreach (var guy in copyOfGuys)
            Console.WriteLine("I deserialized this guy: {0}", guy);
        Console.WriteLine();

        var dudes = JsonSerializer.Deserialize<Stack<Dude>>(jsonString);
        while (dudes.Count > 0)
            Console.WriteLine($"Next dude: {dudes.Pop().Name} with {dudes.Pop().Hair} hair");
    }
}