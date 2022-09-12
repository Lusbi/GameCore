using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
using System.Text;

public class CreateUIBaseTemplate : EditorWindow
{
    private static CreateUIBaseTemplate createUIBaseTemplate;
    [MenuItem("Assets/模版/介面")]
    public static void CreateWindow()
    {
        createUIBaseTemplate = GetWindow<CreateUIBaseTemplate>();
        createUIBaseTemplate.titleContent = new GUIContent("創建 UI Script");
        createUIBaseTemplate.maxSize = new Vector2(500 , 150);
        createUIBaseTemplate.Show();
    }

    private string m_uiBaseName;
    private string m_uiViewName;
    private void OnGUI()
    {
        EditorGUILayout.BeginVertical();
        m_uiBaseName = EditorGUILayout.TextField("文檔名稱", m_uiBaseName);
        m_uiViewName = m_uiBaseName + "View";

        EditorGUILayout.LabelField("將會自動創建此介面結構 ：" + m_uiViewName);
        EditorGUILayout.EndVertical();
        EditorGUILayout.BeginHorizontal();
        if (GUILayout.Button("創建"))
        {
            Create();
        }
        if (GUILayout.Button("取消"))
        {
            Cancel();
        }
        EditorGUILayout.EndHorizontal();
    }
    private void Create()
    {
        LoadUIViewTemplate();
        SaveToPath(m_uiViewName);
        LoadUIBaseTemplate();
        SaveToPath(m_uiBaseName);
        AssetDatabase.Refresh();
        Cancel();
    }

    private void Cancel()
    {
        createUIBaseTemplate.Close();
    }

    private StringBuilder stringBuilder = new StringBuilder();
    private void LoadUIBaseTemplate()
    {
        stringBuilder.Length = 0;
        using (StreamReader streamReader = new StreamReader(Application.dataPath + "/GameCore/UI/Template/UIBase_Template.txt"))
        {
            string content = streamReader.ReadToEnd();
            content = content.Replace("$UIName", m_uiBaseName);
            content = content.Replace("$UIViewName", m_uiViewName);
            stringBuilder.Append(content);
        }
    }

    private void LoadUIViewTemplate()
    {
        stringBuilder.Length = 0;
        using (StreamReader streamReader = new StreamReader(Application.dataPath + "/GameCore/UI/Template/UIView_Template.txt"))
        {
            string content = streamReader.ReadToEnd();
            content = content.Replace("$UIViewName", m_uiViewName);
            stringBuilder.Append(content);
        }
    }

    private void SaveToPath(string saveName)
    {
        string path;
        Object obj = Selection.activeObject;
        if (obj == null) path = "Assets";
        else path = AssetDatabase.GetAssetPath(obj.GetInstanceID());
        if (path.Length > 0)
        {
            if (Directory.Exists(path) == false)
            {
                path = path.Remove(path.LastIndexOf("/"));
            }

            using (StreamWriter streamWriter = new StreamWriter(path + "/" + saveName + ".cs"))
            {
                streamWriter.Write(stringBuilder.ToString());
            }
        }
    }
}
