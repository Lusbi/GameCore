using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace GameCore.Define
{
    [CreateAssetMenu(fileName = "Define Settings" , menuName = "Editor Tool/Define Settings")]
    public class DefineScriptable : ScriptableObject
    {
        public List<DefineInfo> defineInfos = new List<DefineInfo>();
    }
}