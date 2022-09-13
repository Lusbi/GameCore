using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameCore.Utils
{
    public static class ArrayUtils
    {
        public static T GetRandom<T>(this IList<T> array)
        {
            return array[Random.Range(0, array.Count)];
        }
    }
}