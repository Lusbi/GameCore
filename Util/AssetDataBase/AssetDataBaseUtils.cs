#if UNITY_EDITOR
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public static class AssetDataBaseUtils
{
    public static string GetAssetPath (string filter , string[] searchInfoFolder = null)
    {
        string[] guids = AssetDatabase.FindAssets(filter, searchInfoFolder);
        if (guids == null || guids.Length == 0)
        {
            return null;
        }
        foreach (string guid in guids)
        {
            return AssetDatabase.GUIDToAssetPath(guid);
        }
        return string.Empty;
    }

    public static List<string> GetAssetPaths(string filter, string[] searchInfoFolder = null)
    {
        string[] guids = AssetDatabase.FindAssets(filter, searchInfoFolder);
        if (guids == null || guids.Length == 0)
        {
            return null;
        }
        List<string> result = new List<string>();
        foreach (string guid in guids)
        {
            result.Add(AssetDatabase.GUIDToAssetPath(guid));
        }
        return result;
    }

    /// <summary>
    /// 僅回傳第一筆
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="fileName"></param>
    /// <returns></returns>
    public static T GetAsset<T>(string filter, string[] searchInfoFolder = null) where T : Object
    {
        string[] guids = AssetDatabase.FindAssets(filter , searchInfoFolder);
        if (guids == null || guids.Length == 0)
        {
            return null;
        }
        foreach (string guid in guids)
        {
            return (T)AssetDatabase.LoadAssetAtPath(AssetDatabase.GUIDToAssetPath(guid), typeof(T));
        }
        return null;
    }
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="filter"></param>
    /// <param name="searchInfoFolder"></param>
    /// <returns></returns>
    public static List<T> GetAssets<T>(string filter, string[] searchInfoFolder = null) where T : Object
    {
        string[] guids = AssetDatabase.FindAssets(filter, searchInfoFolder);
        if (guids == null || guids.Length == 0)
        {
            return null;
        }
        List<T> result = new List<T>();
        foreach (string guid in guids)
        {
            T cache = (T)AssetDatabase.LoadAssetAtPath(AssetDatabase.GUIDToAssetPath(guid), typeof(T));
            if (cache != null)
            {
                result.Add(cache);
            }
        }
        return result;
    }

    /// <summary>
    /// 取得物件資料夾位置
    /// </summary>
    /// <param name="asset"></param>
    /// <returns></returns>
    public static string GetAssetsFolderPath(Object asset)
    {
        return ProjectWindowUtil.GetContainingFolder(AssetDatabase.GetAssetPath(Selection.activeObject));
    }
}

#endif