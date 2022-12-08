using System;

namespace Birds;

internal class Pigeon : Bird
{
    public override Egg[] LayEggs(int numberOfEggs)
    {
        if (numberOfEggs > 0)
        {
            Egg[] eggs = new Egg[numberOfEggs];
            for (int i = 0; i < numberOfEggs; i++)
            {
                if(Bird.Randomizer.Next(4) == 0)
                    eggs[i] = new BrokenEgg("white");
                else
                    eggs[i] = new Egg(Randomizer.NextDouble() * 2 + 1, "white");
            }
            return eggs;

        }
        else
            return base.LayEggs(numberOfEggs);

    }
}
