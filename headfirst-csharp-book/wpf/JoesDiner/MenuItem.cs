using System;

namespace JoesDiner
{
    internal class MenuItem
    {
        public static Random Randomizer = new Random();

        public string[] Proteints = { "Roast beef", "Salami", "Turkey", "Ham", "Pastrami", "Tofu"};
        public string[] Condiments = { "yellow mustard", "brown mustard", "honey mustard",
                                       "mayo", "relish", "french dressing"};
        public string[] Breads = { "rye", "white", "wheat", "pumppernickel", "a roll" };

        public string Description = "";
        public string Price;

        /// <summary>
        /// Generating a random sandwich and creating a price for it.
        /// </summary>
        public void Generate()
        {
            string randomProtein = Proteints[Randomizer.Next(Proteints.Length)];
            string randomCondiment = Condiments[Randomizer.Next(Condiments.Length)];
            string randomBread = Breads[Randomizer.Next(Breads.Length)];
            Description = randomProtein + " with " + randomCondiment + " on " + randomBread;

            decimal bucks = Randomizer.Next(2, 5);
            decimal cents = Randomizer.Next(1, 98);
            decimal price = bucks + (cents * .01M);
            Price = price.ToString();

        }
    }
}
