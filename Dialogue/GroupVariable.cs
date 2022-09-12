using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameCore.Dialogue
{
    public class GroupVariable
    {
        private const float DEFAULT_SPEED_VALUE = 30f;

        /// <summary>
        /// 粗體
        /// </summary>
        public bool isBlod;
        /// <summary>
        /// 斜體
        /// </summary>
        public bool isItalic;
        /// <summary>
        /// 顏色
        /// </summary>
        public bool isColor;
        /// <summary>
        /// 參數字串
        /// </summary>
        public string parameterString;
        /// <summary>
        /// 語句速度
        /// </summary>
        public float speedValue;
        /// <summary>
        /// 是否暫停
        /// </summary>
        public bool isPause;
        /// <summary>
        /// 當前文字內容
        /// </summary>
        public string dialogueContent;
        /// <summary>
        /// 當前指定暫存的文字
        /// </summary>
        public string cacheDialogue;
        /// <summary>
        /// 當前指令結束
        /// </summary>
        public bool currentCommandEnd = true;

        public string getDialogue
        {
            get
            {
                return dialogueContent + cacheDialogue;
            }
        }
        
        public float durationTime
        {
            get
            {
                return 1f / speedValue;
            }
        }

        public void Initialization()
        {
            isBlod = false;
            isItalic = false;
            isColor = false;
            isPause = false;
            parameterString = string.Empty;
            speedValue = DEFAULT_SPEED_VALUE;
            dialogueContent = string.Empty;
            cacheDialogue = string.Empty;
            currentCommandEnd = true;
        }
    }
}