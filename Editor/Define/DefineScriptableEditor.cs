using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace GameCore.Define
{
    [CustomEditor(typeof(DefineScriptable))]
    public class DefineScriptableEditor : Editor
    {
        private DefineScriptable defineScriptable;
        private const string DEFINE_SYMBOL_SEPARATOR = ";";
        private string m_currentDefine;
        private string m_currentResult;
        private Vector2 m_position;
        private bool m_modify;

        private void OnEnable()
        {
            defineScriptable = target as DefineScriptable;
            m_currentDefine = PlayerSettings.GetScriptingDefineSymbolsForGroup(EditorUserBuildSettings.selectedBuildTargetGroup);
            m_currentResult = string.Empty;
            m_modify = false;
            m_position = Vector2.zero;
        }

        public override void OnInspectorGUI()
        {
            EditorGUI.BeginChangeCheck();

            EditorGUILayout.LabelField("當前 Define：",m_currentDefine);
            //base.OnInspectorGUI();
            if (GUILayout.Button("Create"))
            {
                DefineInfo defineInfo = new DefineInfo();
                defineInfo.description = $"<i>填入 Define 用途描述</i>";
                defineInfo.defineString = $"<i>New_Define_Key</i>";
                defineInfo.state = false;
                defineScriptable.defineInfos.Add(defineInfo);
            }
            if (GUILayout.Button("All Enable"))
            {
                for (int i = 0; i < defineScriptable.defineInfos.Count; i++)
                {
                    defineScriptable.defineInfos[i].state = true;
                }
            }
            if (GUILayout.Button("All Disable"))
            {
                for (int i = 0; i < defineScriptable.defineInfos.Count; i++)
                {
                    defineScriptable.defineInfos[i].state = false;
                }
            }

            m_position = EditorGUILayout.BeginScrollView(m_position); 
            for (int i = 0; i < defineScriptable.defineInfos.Count; i ++)
            {
                defineScriptable.defineInfos[i].state = EditorGUILayout.ToggleLeft("Enabel", defineScriptable.defineInfos[i].state);
                defineScriptable.defineInfos[i].defineString = EditorGUILayout.TextField("Define" , defineScriptable.defineInfos[i].defineString);
                defineScriptable.defineInfos[i].description = EditorGUILayout.TextField("Description", defineScriptable.defineInfos[i].description);

                if (GUILayout.Button("Remove"))
                {
                    defineScriptable.defineInfos.RemoveAt(i);
                    i--;
                    return;
                }
                EditorGUILayout.Space(10);
            }
            EditorGUILayout.EndScrollView();

            if (EditorGUI.EndChangeCheck())
            {
                GetCurrentResult();
                m_modify = m_currentDefine.Equals(m_currentResult) == false;
            }

            if (m_modify == false)
            {
                GUI.enabled = false;
            }
            Apply();
            GUI.enabled = true;
        }

        private void Apply()
        {
            if (GUILayout.Button("Apply"))
            {
                PlayerSettings.SetScriptingDefineSymbolsForGroup(EditorUserBuildSettings.selectedBuildTargetGroup, m_currentResult);
                defineScriptable.SetDirty(true);
                m_currentDefine = PlayerSettings.GetScriptingDefineSymbolsForGroup(EditorUserBuildSettings.selectedBuildTargetGroup);
                m_modify = false;
            }
        }

        private void GetCurrentResult()
        {
            m_currentResult = string.Empty;
            for (int i = 0; i < defineScriptable.defineInfos.Count; i++)
            {
                if (defineScriptable.defineInfos[i].defineString.Contains("<") || string.IsNullOrEmpty(defineScriptable.defineInfos[i].defineString))
                {
                    continue;
                }
                if (defineScriptable.defineInfos[i].state == false)
                {
                    continue;
                }
                m_currentResult += $"{defineScriptable.defineInfos[i].defineString}{DEFINE_SYMBOL_SEPARATOR}";
            }
        }
    }
}