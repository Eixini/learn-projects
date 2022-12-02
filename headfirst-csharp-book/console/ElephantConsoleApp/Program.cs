namespace ElephantConsoleApp;

class Program
{
    static void Main(string[] args)
    {
        Elephant lucinda = new Elephant() {Name = "Lucinda", EarSize = 33 };
        Elephant lloyd = new Elephant() {Name = "Lloyd", EarSize = 40  };

        while (true)
        {
            Console.WriteLine("Please, press key for: '\n'" +
                "1 - Lloyd '\n' 2 - Lucinda '\n' 3 - to swap '\n' 5 - Says" +
                "'\n' Q - Quit" + '\n');
            // Считывание нажатие к клавиатуры
            char inputValue = Console.ReadKey(true).KeyChar;

            switch (inputValue)
            {
                case '1':
                    Console.WriteLine($"You pressed {inputValue} , calling lloyd.WhoIAm()");
                    lloyd.WhoIAm();
                    Console.WriteLine();
                    break;
                case '2':
                    Console.WriteLine($"You pressed {inputValue} , calling lucinda.WhoIAm()");
                    lloyd.WhoIAm();
                    Console.WriteLine();
                    break;
                case '3':
                    Elephant elementForSwap;
                    elementForSwap = lloyd;
                    lloyd = lucinda;
                    lucinda = elementForSwap;
                    Console.WriteLine("References have been swapped");
                    break;
                case '5':
                    lucinda.SpeakTo(lloyd, "Hi, Lloyd!");
                    break;
                case 'Q':
                    return;
                case 'q':
                    return;
                default:
                    Console.WriteLine();
                    break;

            }
        }
    }
}
