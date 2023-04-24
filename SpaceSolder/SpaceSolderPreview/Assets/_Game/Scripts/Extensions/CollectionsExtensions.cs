using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class CollectionsExtensions
{
    public static T GetRandom<T>(this ICollection<T> collection)
    {
        return collection.ElementAt(Random.Range(0, collection.Count));
    }

    public static int GetNextIndex<T>(this ICollection<T> collection, int currentIdex)
    {
        var nextIndex = currentIdex + 1;

        return nextIndex >= collection.Count ? 0 : nextIndex < 0 ? collection.Count - 1 : nextIndex;
    }

    public static bool IsNullOrEmpty<T>(this ICollection<T> collection)
    {
        return collection == null || collection.Count == 0;
    }
}
