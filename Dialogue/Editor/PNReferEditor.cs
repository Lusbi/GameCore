using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace GameCore.Dialogue
{
    [CustomEditor(typeof(PNRefer))]
    public class PNReferEditor : Editor
    {
        private PNRefer pnRefer;
        private List<ReferInfo> infos = new List<ReferInfo>();
        private Vector2 scrollPos = Vector2.zero;
        
        public override void OnInspectorGUI()
        {
            pnRefer = target as PNRefer;   
            infos = pnRefer.referInfos;

            EditorGUILayout.BeginVertical();

            scrollPos = EditorGUILayout.BeginScrollView(scrollPos);
            for (int i = 0 , Count = infos.Count; i < Count; i ++)
            {
                EditorGUILayout.BeginHorizontal();
                EditorGUILayout.LabelField( "編號："+infos[i].id , GUILayout.MaxWidth(30));
                EditorGUILayout.LabelField(infos[i].value , GUILayout.ExpandWidth(true));
                EditorGUILayout.EndHorizontal();
            }
            EditorGUILayout.EndScrollView();
            EditorGUILayout.EndVertical();

            EditorGUILayout.BeginHorizontal();

            if (GUILayout.Button("匯入 +"))
            {

            }
            if (GUILayout.Button("輸出"))
            {

            }
            EditorGUILayout.EndHorizontal();
        }
    }
}