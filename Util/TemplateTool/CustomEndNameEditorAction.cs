#if UNITY_EDITOR
using System.IO;
using UnityEditor;
using UnityEditor.ProjectWindowCallback;
using UnityEngine;

public class CustomEndNameEditorAction : EndNameEditAction
{
    protected CustomReplaceRule customReplaceRule;

    public void SetCustomReplaceRule<T>(T customReplaceRule) where T : CustomReplaceRule
    {
        this.customReplaceRule = customReplaceRule;
    }

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
        AssetDatabase.Refresh();
    }
}

#endif