using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace SequenceImpl;

internal class ManualSportSequence : IEnumerable<Sport>
{
    public IEnumerator<Sport> GetEnumerator() { 
        int maxEnumValue = Enum.GetValues(typeof(Sport)).Length;
        for (int i = 0; i < maxEnumValue; i++)
            yield return (Sport)i;
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
