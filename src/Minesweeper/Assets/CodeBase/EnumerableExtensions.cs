using System.Collections.Generic;

namespace CodeBase
{
    public static class EnumerableExtensions
    {
        public static IEnumerator<T> GetTypedEnumerator<T>(this IEnumerable<T> collection) => 
            collection.GetEnumerator();
    }
}