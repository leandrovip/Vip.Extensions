using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public static partial class Methods
{
    public static bool IsEmpty<T>(this IEnumerable<T> list)
    {
        return !list?.Any() ?? true;
    }

    public static bool IsNotEmpty<T>(this IEnumerable<T> list)
    {
        return !list.IsEmpty();
    }

    public static void ForEach<T>(this IEnumerable items, Action<T> action)
    {
        if (items == null) throw new ArgumentNullException(nameof(items));
        if (action == null) throw new ArgumentNullException(nameof(action));
        foreach (var item in items) action((T) item);
    }

    public static void ForEach<T>(this IEnumerable<T> items, Action<T> action)
    {
        if (items == null) throw new ArgumentNullException(nameof(items));
        if (action == null) throw new ArgumentNullException(nameof(action));
        foreach (T item in items) action(item);
    }

    public static IEnumerable<T> GetMoreThanOnceRepeated<T>(this IEnumerable<T> extList, Func<T, object> groupProps) where T : class
    {
        return extList.GroupBy(groupProps).SelectMany(z => z.Skip(1));
    }

    public static IEnumerable<T> GetAllRepeated<T>(this IEnumerable<T> extList, Func<T, object> groupProps) where T : class
    {
        return extList.GroupBy(groupProps).Where(z => z.Count() > 1).SelectMany(z => z);
    }

    public static bool ExistsRepeated<T>(this IEnumerable<T> list, Func<T, object> groupProps) where T : class
    {
        return GetAllRepeated(list, groupProps).Any();
    }

    public static bool NotExistsRepeated<T>(this IEnumerable<T> list, Func<T, object> groupProps) where T : class
    {
        return !ExistsRepeated(list, groupProps);
    }
}