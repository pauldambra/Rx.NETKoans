using System.Collections.Generic;

namespace Koans.Utils
{
    public static class Range
    {
        public static IEnumerable<int> Create(int start, int end)
        {
            var current = start;
            var step = start < end ? 1 : -1;
            yield return current;
            while (current != end)
            {
                current += step;
                yield return current; 
            }
        }
    }
}