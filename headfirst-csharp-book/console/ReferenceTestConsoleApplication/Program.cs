namespace ReferenceTestConsoleApplication;

internal class Program
{
    static void Main(string[] args)
    {
        ClassA classA = new ClassA();
        ClassB classB = new ClassB();
        ClassC classC = new ClassC();

        Console.Write("======> classA ref: ");
        classA.aFunc();
        Console.Write("======> classB ref: ");
        classB.aFunc();
        classB.bFunc();
        Console.Write("======> classC ref: ");
        classC.aFunc();
        classC.cFunc();

        ClassA classArefB = new ClassB();
        Console.Write("======> classArefB ref: ");
        classArefB.aFunc();
    }
}