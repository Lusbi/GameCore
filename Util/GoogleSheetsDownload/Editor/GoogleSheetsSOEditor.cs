using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UIElements;

namespace GameCore.GoogleSheets
{
    [CustomEditor(typeof(GoogleSheetsSO))]
    public class GoogleSheetsSOEditor : Editor
    {
        private GoogleSheetsSO m_googleSheetsSO;

        private void OnEnable()
        {
            m_googleSheetsSO = target as GoogleSheetsSO;
        }

        public override void OnInspectorGUI()
        {
            if (m_googleSheetsSO == null)
            {
                return;
            }

            if (GUILayout.Button("Download"))
            {
                m_googleSheetsSO.Download();
            }

            base.OnInspectorGUI();
        }
    }
}