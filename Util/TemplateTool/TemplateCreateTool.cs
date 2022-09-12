#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEditor.ProjectWindowCallback;
using UnityEngine;

public static class TemplateCreateTool
{
    /// <summary>
    /// 創建文件模板
    /// </summary>
    /// <param name="sourcePath">來源文件</param>
    /// <param name="createPath">創建文件</param>
    public static void CreateTxtTemplate<T, T1>(string sourcePath, string createName, T1 rule = null) where T : CustomEndNameEditorAction where T1 : CustomReplaceRule
    {
        string resourceFile = Path.Combine(Application.dataPath, sourcePath.Replace("Assets/",""));

        Texture2D csIcon = EditorGUIUtility.IconContent("cs Script Icon").image as Texture2D;

        T endNameEditAction = ScriptableObject.CreateInstance<T>();
        endNameEditAction.SetCustomReplaceRule(rule);
        ProjectWindowUtil.StartNameEditingIfProjectWindowExists(0, endNameEditAction, createName, csIcon, resourceFile);
    }

    /// <summary>
    /// 創建文件模板
    /// </summary>
    /// <param name="sourcePath">來源文件</param>
    /// <param name="createPath">創建文件</param>
    public static void CreateTxtTemplate<T>(string sourcePath, string createName) where T : CustomEndNameEditorAction
    {
        string resourceFile = Path.Combine(Application.dataPath, sourcePath.Replace("Assets/", ""));

        Texture2D csIcon = EditorGUIUtility.IconContent("cs Script Icon").image as Texture2D;

        T endNameEditAction = ScriptableObject.CreateInstance<T>();
        ProjectWindowUtil.StartNameEditingIfProjectWindowExists(0, endNameEditAction, createName, csIcon, resourceFile);
    }
}

#endif