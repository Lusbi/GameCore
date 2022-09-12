#if UNITY_EDITOR
using System.IO;
using UnityEditor;
using UnityEngine;

public class CustomEndNameEditorActionToEditorFolder : CustomEndNameEditorAction
{
    public override void Action(int instanceId, string pathName, string resourceFile)
    {
        string text = File.ReadAllText(resourceFile);

        StreamWriter sr = File.CreateText(pathName);
        if (customReplaceRule == null)
        {
            customReplaceRule = new CustomReplaceRule();
            customReplaceRule.SetClassName(pathName);
        }

        text = customReplaceRule.Replace(text);
        sr.WriteLine(text);
        sr.Close();
        AssetDatabase.ImportAsset(pathName);
        ProjectWindowUtil.ShowCreatedAsset(AssetDatabase.LoadAssetAtPath<TextAsset>(pathName));

        Object asset = AssetDatabase.LoadAssetAtPath<TextAsset>(pathName);
        // 移到該位置的 Editor Folder
        if (asset != null)
        {
            string oldPath = AssetDatabase.GetAssetPath(asset);
            string newPath = Path.Combine(AssetDataBaseUtils.GetAssetsFolderPath(asset), "Editor");
            if (!Directory.Exists(newPath))
            {
                Directory.CreateDirectory(newPath);
            }
            AssetDatabase.Refresh();
            newPath = newPath + "/" + asset.name + ".cs";
            AssetDatabase.MoveAsset(oldPath, newPath);
            AssetDatabase.ImportAsset(newPath);
            AssetDatabase.Refresh();
        }
    }
}

#endif