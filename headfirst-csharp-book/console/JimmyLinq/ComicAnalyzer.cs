﻿using System.Collections.Generic;
using System.Linq;

namespace JimmyLinq;

public class ComicAnalyzer
{
    private static PriceRange CalculatePriceRange(Comic comic, IReadOnlyDictionary<int,decimal> prices) => 
        (prices[comic.Issue] < 100) ? PriceRange.Cheap : PriceRange.Expensive;

    public static IEnumerable<IGrouping<PriceRange, Comic>> GroupComicsByPrice(IEnumerable<Comic> comics, IReadOnlyDictionary<int, decimal> prices)
    {
        var grouped = comics.OrderBy(comic => prices[comic.Issue])
                            .GroupBy(comic => CalculatePriceRange(comic, prices));
        return grouped;
    }

    public static IEnumerable<string> GetReviews(IEnumerable<Comic> comics, IEnumerable<Review> reviews)
    {
        var joined = comics.OrderBy(comic => comic.Issue)
                           .Join(reviews,
                                 comic => comic.Issue,
                                 reviews => reviews.Issue,
                                 (comic, review) => $"{review.Critic} rated #{comic.Issue} '{comic.Name}' {review.Score:0.00}");

        return joined;
    }
}
