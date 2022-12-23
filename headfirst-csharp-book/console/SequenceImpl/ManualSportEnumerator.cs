using System.Collections;

namespace SequenceImpl;

internal class ManualSportEnumerator : IEnumerator<Sport>
{
    int current = -1;

    public Sport Current { get => (Sport)current; }
    object IEnumerator.Current => current;

    public void Dispose() { return; }

    public bool MoveNext()
    {
        var maxEnumValue = Enum.GetValues(typeof(Sport)).Length;
        if ((int)current >= maxEnumValue - 1)
            return false;
        current++;
        return true;
    }

    public void Reset() { current = 0; }

}
