using UnityEngine;
using System;

namespace GameCore.Log
{
    /*
     * 由於輸出Log會配置記憶體並影響效能
     * 此類別用來取代原本的Debug.Log，可控制是否真的要輸出Log
     * 
     * 目前預設規則
     * 1.編輯器中會輸出Log
     * 2.非編輯器若要輸出，要定義DEBUG
     */
    public static class eLog
    {
        // 若直接寫成函式(如下方的Log(object message))，編輯器中雙擊Log那行時會跳到這邊的函式而不是呼叫MyDebug.Log的地方
        // 若要正確跳到呼叫的地方，網路上有找到兩個方法，1.把自己寫的Log類別包成DLL 2.寫成Action(目前使用的方法)

        public static Action<string> Log = Debug.Log;
        public static Action<string> Warning = Debug.LogWarning;
        public static Action<string> Error = Debug.LogError;
    }
}