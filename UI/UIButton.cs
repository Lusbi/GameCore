using System;
using UnityEngine;
using UnityEngine.UI;

namespace GameCore.UI
{
    [RequireComponent(typeof(UIEventListener))]
    public class UIButton : MonoBehaviour
    {
        public RectTransform rectTransform { get; protected set; }

        private bool m_hover = false;
        private bool m_selected = false;
        private bool m_locked = false;

#if UNITY_EDITOR
        [ContextMenu("Reset UIButton")]
        private void ResetUIButton()
        {
            m_fxBases = GetComponents<ButtonFXBase>();
        }
#endif

        [SerializeField] private ButtonFXBase[] m_fxBases = null;

        public object data { get; set; } = null;
        public UIEventListener eventListener { get; protected set; }

        /// <summary>
        /// 停留狀態
        /// </summary>
        public bool hover
        {
            get
            {
                return m_hover;
            }
            set
            {
                if (m_hover == value)
                {
                    onHover?.Invoke(this, m_hover);
                    return;
                }

                m_hover = value;

                if (m_locked != true)
                {
                    for (int i = 0, count = m_fxBases.Length; i < count; i++)
                    {
                        m_fxBases[i].onHover(m_hover);
                    }

                    if (m_hover == false)
                    {
                        for (int i = 0, count = m_fxBases.Length; i < count; i++)
                        {
                            m_fxBases[i].onSelected(m_selected);
                        }
                    }
                }

                onHover?.Invoke(this, m_hover);
            }
        }

        /// <summary>
        /// 選擇狀態
        /// </summary>
        public bool selected
        {
            get
            {
                return m_selected;
            }
            set
            {
                if (m_selected == value)
                {
                    return;
                }

                m_selected = value;

                for (int i = 0, count = m_fxBases.Length; i < count; i++)
                {
                    m_fxBases[i].onSelected(m_selected);
                }
            }
        }

        /// <summary>
        /// 鎖定狀態
        /// </summary>
        public bool locked
        {
            get
            {
                return m_locked;
            }
            set
            {
                // 不重複執行
                if (m_locked == value)
                {
                    return;
                }

                m_locked = value;
                if (m_locked)
                {
                    hover = false;
                    selected = false;
                }

                for (int i = 0, count = m_fxBases.Length; i < count; i++)
                {
                    m_fxBases[i].onLocked(m_locked);
                }
            }
        }

        /// <summary>
        /// 快顯提示位置
        /// </summary>
        private Vector2 m_tipPos = Vector2.zero;
        private bool setTipPos = false;

        public Action<UIButton> onClicked;
        public Action<UIButton> onRightClicked;
        public Action<UIButton, Vector2> onClickDown;
        public Action<UIButton, Vector2> onClickUp;
        public Action<UIButton, bool> onHover;

        [Tooltip("按鍵文字")]
        public Text buttonText;

        private void OnEnable()
        {
            if (m_fxBases == null || m_fxBases.Length == 0)
            {
                m_fxBases = GetComponents<ButtonFXBase>();
            }
        }

        public void SetButtonText(string text)
        {
            if (buttonText == null)
            {
                buttonText = GetComponentInChildren<Text>();
            }
            if (buttonText != null)
            {
                buttonText.text = text;
            }
        }

        /// <summary>
        /// 取得quickTip顯示位置
        /// </summary>
        public Vector2 GetTipPos()
        {
            if (!setTipPos)
            {
                setTipPos = true;
            }

            return m_tipPos;
        }

        public void Show(bool show)
        {
            //selected = false;
            //hover = false;

            gameObject.SetActive(show);
        }

        public void ClearEvents()
        {
            onClicked = null;
            onRightClicked = null;
            onClickDown = null;
            onClickUp = null;
            onHover = null;
        }

        private void Awake()
        {
            rectTransform = transform as RectTransform;

            eventListener = UIEventListener.Get(gameObject);
            eventListener.onClick = OnClick;
            eventListener.onRightClick = OnRightClick;
            eventListener.onDown = OnPointerDown;
            eventListener.onUp = OnPointerUp;
            eventListener.onEnter = OnPointerEnter;
            eventListener.onExit = OnPointerExit;
        }

        private void OnClick(GameObject obj)
        {
            if (m_locked)
            {
                return;
            }

            onClicked?.Invoke(this);
        }
        private void OnRightClick(GameObject obj)
        {
            if (m_locked)
            {
                return;
            }

            onRightClicked?.Invoke(this);
        }
        private void OnPointerDown(GameObject obj, Vector2 position)
        {
            if (m_locked)
            {
                return;
            }

            for (int i = 0, count = m_fxBases.Length; i < count; i++)
            {
                m_fxBases[i].onClickDown();
            }

            if (onClickDown != null)
            {
                onClickDown(this, position);
            }
        }
        private void OnPointerUp(GameObject obj, Vector2 position)
        {
            if (m_locked)
            {
                return;
            }

            for (int i = 0, count = m_fxBases.Length; i < count; i++)
            {
                m_fxBases[i].onClickUp();
            }

            if (onClickUp != null)
            {
                onClickUp(this, position);
            }
        }
        private void OnPointerEnter(GameObject obj)
        {
            hover = true;
        }
        private void OnPointerExit(GameObject obj)
        {
            hover = false;
        }


    }
}
