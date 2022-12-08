using System;

namespace Birds;

internal class Ostrich : Bird
{
    public override Egg[] LayEggs(int numberOfEggs)
    {
        if (numberOfEggs > 0)
        {
            Egg[] eggs = new Egg[numberOfEggs];
            for (int i = 0; i < numberOfEggs; i++)
                eggs[i] = new Egg(Randomizer.NextDouble() + 12, "speckled");
            return eggs;
        }
        else
            return base.LayEggs(numberOfEggs);

    }
}
