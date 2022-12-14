using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Page429ConsoleApp;

internal class FunnyFunny : IClown
{
    private string funnyThingIHave;
    public string FunnyThingIHave { get { return funnyThingIHave; } }

    public FunnyFunny(string mes)
    {
        funnyThingIHave = mes;
    }

    public void Honk()
    {
        Console.WriteLine("Hi kids! I have a {0}", funnyThingIHave);
    }
}
