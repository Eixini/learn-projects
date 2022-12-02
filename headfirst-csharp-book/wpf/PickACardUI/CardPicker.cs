using System;

namespace PickACardUI
{
    internal class CardPicker
    {
        static Random random = new Random();
        public static string[] PickSomeCards(int numberOfCards)
        {
            string[] pickedCards = new string[numberOfCards];
            for(int i = 0; i < numberOfCards; i++)
            {
                pickedCards[i] = RandomValue() + " of " + RandomSuit();
            }

            return pickedCards;
        }

        private static string RandomSuit()
        {
            int value = random.Next(1,5);   // Получить случайное число от 1 до 4 включительно

            if (value == 1) return "Spades";
            if (value == 2) return "Hearts";
            if (value == 3) return "Clubs";
            return "Diamonds";
        }

        private static string RandomValue()
        {
            int value = random.Next(1, 14);
            if (value == 1) return "Ace";        // Если 1, то вернуть Туз
            if (value == 11) return "Jack";      // Если 11, то вернуть Валет
            if (value == 12) return "Queen";     // Если 12, то вернуть Даму
            if (value == 13) return "King";      // Если 13, то вернуть Короля
            return value.ToString();             // Иначе вернуть численный номинал
        }
    }
}
