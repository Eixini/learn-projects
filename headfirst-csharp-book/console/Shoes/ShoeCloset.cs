using System.Collections.Generic;

namespace Shoes;

internal class ShoeCloset
{
    private readonly List<Shoe> shoes = new List<Shoe>();

    /// <summary>
    /// Выводит список обуви
    /// </summary>
    public void PrintShoes()
    {
        if (shoes.Count == 0)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.BackgroundColor = ConsoleColor.White;
            Console.WriteLine("\nThe shoe closet is empty.");
            Console.ResetColor();
        }
        else
        {
            Console.WriteLine("\nThe shoe closet contains:");
            int i = 1;
            foreach (Shoe shoe in shoes)
                Console.WriteLine($"Shoe #{i++}: {shoe.Description}");
        } 
    }

    /// <summary>
    /// Добавление новой пары обуви в коллекцию
    /// </summary>
    public void AddShoe()
    {
        Console.WriteLine("\nAdd a shoe");
        for (int i = 0; i < 6; i++)
            Console.WriteLine($"Press {i} to add a {(Style)i}");
        Console.Write("Enter a style: ");
        if(int.TryParse(Console.ReadKey().KeyChar.ToString(), out int style))
        {
            Console.Write("\nEnter the color: ");
            string color = Console.ReadLine();
            Shoe shoe = new Shoe((Style)style, color);
            shoes.Add(shoe);
        }
    }

    /// <summary>
    /// Удаление пары обуви из коллекции, если она имеется
    /// </summary>
    public void RemoveShoe()
    {
        Console.Write("\nEnter the number of the shoe to remove: ");
        if(int.TryParse(Console.ReadKey().KeyChar.ToString(), out int shoeNumber) && 
            (shoeNumber >= 1) && (shoeNumber <= shoes.Count))
        {
            Console.WriteLine($"\nRemoving {shoes[shoeNumber - 1].Description}");
            shoes.RemoveAt(shoeNumber - 1);
        }
    }
}
