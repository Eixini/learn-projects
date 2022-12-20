using System.Collections.Generic;
using System.Linq;

namespace JimmyComic;

public class Program  {
    public static void Main(string[] args)
    {
        var mostExpensive =
            from comic in Comic.Catalog
            where Comic.Prices[comic.Issue] > 500
            orderby Comic.Prices[comic.Issue] descending
            select $"{comic} is worth {Comic.Prices[comic.Issue]} $";

        foreach (var comic in mostExpensive)
            Console.WriteLine(comic);
    }
}