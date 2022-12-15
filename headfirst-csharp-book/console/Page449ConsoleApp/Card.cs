using System;

namespace Page449ConsoleApp;

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
}
