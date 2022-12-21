using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq;

namespace Page526ConsoleLINQ
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var random = new Random();
            var numbers = new List<int>();
            var length = random.Next(50, 150);
            for (int i = 0; i < length; i++)
                numbers.Add(random.Next(100));
            
            Console.WriteLine($@"Stats for these {numbers.Count} numbers:" + '\n' +
            $"The first 5 numbers: {String.Join(", ", numbers.Take(5))}" + '\n' +
            //$"The last 5 numbers: {String.Join(", ", numbers.TakeLast(5))}" + '\n' +
            $"The first is {numbers.First()} and the lasi is {numbers.Last()}"  + '\n'+
            $"The smallest is {numbers.Min()}, and the biggest is {numbers.Max()}"  + '\n'+
            $"The sum is {numbers.Sum()}"  + '\n' +
            $"The average is {numbers.Average():F2}" + '\n'
            );
            
            
        }
    }
}