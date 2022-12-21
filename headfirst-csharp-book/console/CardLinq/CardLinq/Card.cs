namespace CardLinq;

internal class Card : IComparable<Card>
{
    public Values Value { get; private set; }
    public Suits Suit { get; private set; }

    public Card(Values value, Suits suit)
    {
        this.Suit = suit;
        this.Value = value;
    }

    public string Name { get { return $"{Value} of {Suit}"; } }

    public int CompareTo(Card other) => new CardComparerByValue().Compare(this, other);

    public override string ToString() => Name;

}
