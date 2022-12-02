using System;

namespace PickRandomCards
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the number of cards to pick: ");
            string line = Console.ReadLine();
            if (int.TryParse(line, out int numberOfCards))
            {
                foreach(string card in CardPicker.PickSomeCards(numberOfCards))
                    Console.WriteLine(card);
            }
            else
            {
                Console.WriteLine("");
            }

            //Random random = new Random();
            //double[] randomDoubles = new double[20];
            //for (int i = 0; i < 20; i++)
            //    randomDoubles[i] = random.NextDouble();
            //foreach (double ranArr in randomDoubles)
            //    Console.WriteLine(ranArr);
        }
    }
}
