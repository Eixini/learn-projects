namespace LumberjackAndFlapjack;

internal class Lumberjack
{
    public string Name { get; private set; }
    private Stack<Flapjack> flapjackStack;

    public Lumberjack(string name)
    {
        this.Name = name;
    }

    public void TakeFlapjack(Flapjack flapjack)
    {
        flapjackStack.Push(flapjack);
    }

    public void EatFlapjack()
    {
        Console.WriteLine($"{Name} is eating flapjacks");
        while (flapjackStack.Count > 0)
            Console.WriteLine($"{Name} ate a {flapjackStack.Pop().ToString().ToLower()} flapjack");
    }

}
