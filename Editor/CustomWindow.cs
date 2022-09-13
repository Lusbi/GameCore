using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class CustomWindow : EditorWindow
{
    private static List<string> guids = new List<string>();
    private int lastCount = 0;
    private List<Object> objects = new List<Object>();

    private const string EDITORPREFS_CACHE_GUID = "Custom_Cache_Guids";

    [MenuItem("Assets/自定義視窗/新增")]
    private static void AddToCustomWindow()
    {
        if (Selection.activeObject == null)
        {
            return;
        }
        Add(AssetDatabase.AssetPathToGUID(AssetDatabase.GetAssetPath(Selection.activeObject)));
    }

    public static void Add(string guid)
    {
        if (guids.Contains(guid) == false)
        {
            guids.Add(guid);
        }

        string editorprefs_saveString = string.Empty;
        for (int i = 0, Count = guids.Count; i < Count; i++)
        {
            editorprefs_saveString += guids[i];
            editorprefs_saveString += "\n";
        }
        EditorPrefs.SetString(EDITORPREFS_CACHE_GUID, editorprefs_saveString);
    }
    public static void Remove(string guid)
    {
        guids.Remove(guid);
    }

    [MenuItem("Assets/自定義視窗/開啟視窗")]
    private static void OpenWindow()
    {
        CustomWindow customWindow = GetWindow<CustomWindow>();
        customWindow.Show();
    }

    protected void OnEnable()
    {
        string editorprefs_guids = EditorPrefs.GetString(EDITORPREFS_CACHE_GUID);
        guids = new List<string>(editorprefs_guids.Split('\n'));
    }

    protected void OnGUI()
    {
        if (lastCount != guids.Count)
        {
            Reload();
            Repaint();
        }

        bool backColorUpdate = false;
        Color originalColor = GUI.contentColor;
        string currentSelectName = Selection.activeObject == null ? string.Empty : Selection.activeObject.name;
        for (int i = 0, Count = objects.Count; i < Count; i++)
        {
            if (objects[i] == null)
            {
                objects.Remove(objects[i]);
                Count--;
                i--;
                continue;
            }

            backColorUpdate = currentSelectName != string.Empty && currentSelectName.Equals(objects[i].name);
            EditorGUILayout.BeginHorizontal();

            if (backColorUpdate)
            {
                GUI.backgroundColor = Color.red;

                if (GUILayout.Button(objects[i].name, GUI.skin.box, GUILayout.ExpandWidth(true)))
                {
                    Selection.activeObject = objects[i];
                }
            }
            else
            {
                if (GUILayout.Button(objects[i].name, GUI.skin.label, GUILayout.ExpandWidth(true)))
                {
                    Selection.activeObject = objects[i];
                }
            }
            if (GUILayout.Button("移除", GUILayout.Width(50)))
            {
                objects.Remove(objects[i]);
                i--;
                Count--;
            }

            GUI.backgroundColor = originalColor;
            EditorGUILayout.EndHorizontal();
        }
    }

    private void Reload()
    {
        objects.Clear();
        lastCount = guids.Count;

        foreach (string guid in guids)
        {
            objects.Add((Object)AssetDatabase.LoadAssetAtPath(AssetDatabase.GUIDToAssetPath(guid), typeof(Object)));
        }
    }
}
