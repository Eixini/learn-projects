using System;

namespace SortCardConsoleApp;

internal class Card
{
    public Values Value { get; private set; }
    public Suits Suit { get; private set; }

    public Card(Values value, Suits suit)
    {
        this.Suit = suit;
        this.Value = value;
    }

    public string Name { get { return $"{Value} of {Suit}"; } }

    public override string ToString()
    {
        return Name;
    }
}
