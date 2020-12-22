using UnityEngine;
using UnityEngine.UI;

namespace GameCore.UI
{
    [AddComponentMenu("UI/ButtonFX/Sprite"), RequireComponent(typeof(UIButton))]
    public class ButtonFXSprite : ButtonFXBase
    {
        [SerializeField] private Image m_image = null;
        [SerializeField] private SpriteSet m_spriteSet = null;

        public override void onClickDown()
        {
            if (m_image == null)
                return;

            m_image.sprite = m_spriteSet.Click;
        }

        public override void onClickUp()
        {
            if (m_image == null)
                return;

            m_image.sprite = (m_isHover)? m_spriteSet.Hover : m_spriteSet.Normal;
        }

        public override void onHover(bool isHovered)
        {
            if (m_image == null)
                return;

            m_isHover = isHovered;

            if (isHovered)
                m_image.sprite = m_spriteSet.Hover;
            else
                m_image.sprite = m_spriteSet.Normal;
        }

        public override void onLocked(bool isLocked)
        {
            if (m_image == null)
                return;

            if (isLocked)
                m_image.sprite = m_spriteSet.Lock;
            else
                m_image.sprite = m_spriteSet.Normal;
        }

        public override void onSelected(bool isSelected)
        {
            if (m_image == null)
                return;

            if (isSelected)
                m_image.sprite = m_spriteSet.Select;
            else
                m_image.sprite = m_spriteSet.Normal;
        }
    }
}
