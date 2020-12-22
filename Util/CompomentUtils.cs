using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameCore.Utils
{
    public static class CompomentUtils
    {
        public static T AddComponentIfNull<T>(this GameObject gameObject) where T : Component
        {
            T component = gameObject.GetComponent<T>();
            if (component == null)
            {
                component = gameObject.AddComponent<T>();
            }
            return component;
        }
    }
}