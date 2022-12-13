using System;

namespace Page400ConsoleApp;

internal class TallGuy : IClown
{
    public string Name;
    public int Height;

    public string FunnyThingIHave => "big shoes";

    public void TalkAboutYorself() => Console.WriteLine($"My name is {Name} and I'm {Height} inches tall.");

    public void Honk() => Console.WriteLine("Honk honk!");

}
