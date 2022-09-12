using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GameCore;

namespace GameCore.Utils
{ 
    public static class UIUtils 
    {
        public static void SetImage(this Image m_image , Sprite sprite)
        {
            if (m_image == null)
            {
                return;
            }
            if (sprite == null)
            {
                return;
            }

            m_image.sprite = sprite;
        }
    }
}