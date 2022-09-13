using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public static class EditorUtils
{
    public static void SetDirty(this Object obj , bool save = false)
    {
#if UNITY_EDITOR
        EditorUtility.SetDirty(obj);
        if (save)
        {
            AssetDatabase.SaveAssets();
        }
#endif
    }
}
