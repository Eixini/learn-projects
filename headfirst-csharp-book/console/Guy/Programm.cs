namespace GuyAndCash;

internal class Programm {
    static void Main(string[] args) {
        Guy joe = new Guy() {Name = "Joe", Cash = 50 };
        Guy bob = new Guy() {Name = "Bob", Cash = 100 };

        while(true) {
            joe.WriteMyInfo();
            bob.WriteMyInfo();

            Console.Write("Enter a amount: ");
            string howMuch = Console.ReadLine();
            if (howMuch == "") return;

            if (int.TryParse(howMuch, out int amount))
            {
                Console.Write("Who should give the cash: ");
                string whichGuy = Console.ReadLine();
                if (whichGuy == "Joe")
                {
                    joe.GiveCash(amount);
                    bob.ReceiveCash(amount);
                }
                else if (whichGuy == "Bob")
                {
                    bob.GiveCash(amount);
                    joe.ReceiveCash(amount);
                }
                else
                    Console.WriteLine("Please enter 'Joe' or 'Bob'");
            }
            else
                Console.WriteLine("Please enter an amount (or a blank line to exit)");
        }
    }
}
