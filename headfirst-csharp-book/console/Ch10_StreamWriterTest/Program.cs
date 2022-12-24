using System.IO;

namespace Ch10_StreamWriterTest;

internal class Program
{
    static void Main(string[] args)
    {
        StreamWriter streamWriter = new StreamWriter("secret_plan.txt");

        streamWriter.WriteLine("How I'll defeat Captain Amazing");
        streamWriter.WriteLine("Another genius secret plan by The Swindler");
        streamWriter.WriteLine("I'll unleash my army of clones upon the citizens of Objectville.");

        string location = "the mall";
        for(int number = 1; number <= 5; number++)
        {
            streamWriter.WriteLine($"Clone #{0} attacks {1}", number, location);
            location = (location == "the mall") ? "downtown" : "the mall";
        }
        streamWriter.Close();
    }
}