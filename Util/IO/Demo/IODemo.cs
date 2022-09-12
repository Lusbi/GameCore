#if ODIN_INSPECTOR && UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameCore.Utils;
using Sirenix.OdinInspector;


public class IODemo : MonoBehaviour
{
    [LabelText("父資料夾位置")] public string folderParent = "";
    [LabelText("資料夾名稱")] public string folderName = "";

    [Space(10)]
    [HideLabel] public string resultPath = "";

    [Button("創建於 Asset 底下")]
    private void CreateFolder()
    {
        resultPath = IOUtils.Folder.Create(folderParent, folderName);
    }
    [Button("刪除")]
    private void RemoveFolder()
    {
        IOUtils.Folder.Remove(resultPath);
    }
}
#endif