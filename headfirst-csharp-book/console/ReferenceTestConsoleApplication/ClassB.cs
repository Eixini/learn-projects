using System;

namespace ReferenceTestConsoleApplication;

internal class ClassB : ClassA
{
    public override void aFunc()
    {
        base.aFunc();
        Console.WriteLine("(override in class B)");
    }

    public void bFunc()
    {
        Console.WriteLine("This is B class!");
    }
}
