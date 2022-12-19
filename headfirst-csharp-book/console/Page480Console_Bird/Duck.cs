using System.Collections.Generic;

namespace Page480Console_Bird;

internal class Duck : Bird, IComparable<Duck>
{
    public int Size { get; set; }
    public KindOfDuck Kind { get; set; }

    public int CompareTo(Duck duckToCompare)
    {
        if (this.Size > duckToCompare.Size)
            return 1;
        else if (this.Size < duckToCompare.Size)
            return -1;
        else
            return 0;
    }

    public override string ToString()
    {
        return $"A {Size} inch {Kind}";
    }
}
