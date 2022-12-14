using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Page429ConsoleApp;

internal class ScaryScary : FunnyFunny, IScaryClown
{
    private readonly int scaryThingCount;

    public string ScaryThingIHave { get { return $"{scaryThingCount} spiders"; } }

    public ScaryScary(string mes, int scaryThCount) : base(mes)
    {
        this.scaryThingCount = scaryThCount;
    }

    public void ScareLittleChildren()
    {
        Console.WriteLine($"Boo! Cotcha! Look at my {ScaryThingIHave}!");
    }

}
