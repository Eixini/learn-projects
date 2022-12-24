using System.Text;
using System.Text.Json;

namespace UnicodeTest;

internal class Program
{
    static void Main(string[] args)
    {
        File.WriteAllText("elephant1.txt", "\uD83D\uDC18");
        File.WriteAllText("elephant2.txt", "\U0001F418");
        //File.WriteAllText("eureka.txt", "Eureka!");
        File.WriteAllText("eureka.txt", "שלום", Encoding.Unicode);
        byte[] eurekaBytes = File.ReadAllBytes("eureka.txt");
        foreach (byte b in eurekaBytes)
            Console.Write("{0} ", b);
        Console.WriteLine(Encoding.UTF8.GetString(eurekaBytes));

        foreach (byte b in eurekaBytes)
            Console.Write("{0:x2} ", b);
        Console.WriteLine();

        Console.WriteLine(JsonSerializer.Serialize("ש"));
    }
}