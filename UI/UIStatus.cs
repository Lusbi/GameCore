using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameCore.UI
{
    public enum UIStatus
    {
        None,
        /// <summary>
        /// 關啟中
        /// </summary>
        Enable,
        /// <summary>
        /// 動畫播放中
        /// </summary>
        Animationing,
        /// <summary>
        /// 關閉中
        /// </summary>
        Disable,
    }
}