using System;
using UnityEngine;
using UnityEngine.UI;

namespace GameCore.UI
{
    public abstract class ButtonFXBase : MonoBehaviour
    {
        protected bool m_isHover = false;

        [ContextMenu("AutoReference")]
        private void AutoReference()
        {
            AutoCache(true);
        }

        private void OnValidate()
        {
            AutoCache(false);
        }

        protected virtual void AutoCache(bool forceUpdate = false)
        {

        }

        [Serializable]
        public class ColorSet
        {
            public Color32 Normal = new Color32(255, 255, 255, 255);
            public Color32 Click = new Color32(155, 155, 155, 255);
            public Color32 Selected = new Color32(155, 155, 155, 255);
            public Color32 Hovered = new Color32(155, 155, 155, 255);
            public Color32 Locked = new Color32(155, 155, 155, 255);
        }

        [Serializable]
        public class ScaleSet
        {
            public Vector3 Normal = new Vector3(1f, 1f, 1f);
            public Vector3 Click = new Vector3(0.95f, 0.95f, 0.95f);
            public Vector3 Select = new Vector3(1.05f, 1.05f, 1.05f);
            public Vector3 Hover = new Vector3(1.05f, 1.05f, 1.05f);
            public Vector3 Lock = new Vector3(1f, 1f, 1f);
        }

        [Serializable]
        public class SpriteSet
        {
            public Sprite Normal;
            public Sprite Click;
            public Sprite Select;
            public Sprite Hover;
            public Sprite Lock;
        }

        [Serializable]
        public class GameObjectSet
        {
            public GameObject Clicked;
            public GameObject Selected;
            public GameObject Hover;
            public GameObject Lock;
        }

        public class ImageSet
        {
            public Image clicked;
            public Image selected;
            public Image hover;
            public Image locked;
        }

        public class CanvasGroupSet
        {
            public CanvasGroup clicked;
            public CanvasGroup selected;
            public CanvasGroup hover;
            public CanvasGroup locked;
        }

        public abstract void onClickDown();
        public abstract void onClickUp();
        public abstract void onHover(bool isHovered);
        public abstract void onSelected(bool isSelected);
        public abstract void onLocked(bool isLocked);
    }
}