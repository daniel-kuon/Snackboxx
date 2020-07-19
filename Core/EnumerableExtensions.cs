using System;
using System.Collections.Generic;

namespace Core
{
    public static class EnumerableExtensions
    {
        public static void ForEach<T>(this IEnumerable<T> list, Action<T> action)
        {
            if (list == null) throw new ArgumentNullException(nameof(list));
            if (action == null) throw new ArgumentNullException(nameof(action));
            using var enumerator = list.GetEnumerator();
            while (enumerator.MoveNext())
                action(enumerator.Current);
        }
        public static void ForEach<T>(this IEnumerable<T> list, Action<T,int> action)
        {
            if (list == null) throw new ArgumentNullException(nameof(list));
            if (action == null) throw new ArgumentNullException(nameof(action));
            using var enumerator = list.GetEnumerator();
            var index = 0;
            while (enumerator.MoveNext())
                action(enumerator.Current, index++);
        }
    }
}