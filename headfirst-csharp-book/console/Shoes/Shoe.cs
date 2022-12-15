namespace Shoes;

internal class Shoe
{
    public Style Style { get; private set; }
    public string Color { get; private set; }
    public string Description { get { return $"A {Color} {Style}"; } }

    public Shoe(Style style, string color)
    {
        Style = style;
        Color = color;
    }
}
