using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GameCore.UI
{
    [AddComponentMenu("UI/ButtonFX/Color"), RequireComponent(typeof(UIButton))]
    public class ButtonFXColor : ButtonFXBase
    {
        [Serializable]
        public class GrahpicColors
        {
            public Graphic Control;
            public ColorSet Colors;
        }

        /// <summary>
        /// 進階設定
        /// </summary>
        public bool AdvanceSetting = false;

        // QuickSetting只提供文字、圖形各一組
        [SerializeField] private GrahpicColors m_controlText = null;
        [SerializeField] private GrahpicColors m_controlImage = null;

        // 進階設定 自己開陣列設定
        [SerializeField]
        private List<GrahpicColors> m_controlGraphics = new List<GrahpicColors>();
        private GrahpicColors m_tmpControlGraphic;


        public override void onClickDown()
        {
            if (AdvanceSetting)
            {
                for (int i = 0, count = m_controlGraphics.Count; i < count; i++)
                {
                    m_tmpControlGraphic = m_controlGraphics[i];
                    UpdateColor(m_tmpControlGraphic.Control, m_tmpControlGraphic.Colors.Click);
                }

                return;
            }

            UpdateColor(m_controlText.Control, m_controlText.Colors.Click);
            UpdateColor(m_controlImage.Control, m_controlImage.Colors.Click);
        }

        public override void onClickUp()
        {
            if (AdvanceSetting)
            {
                for (int i = 0, count = m_controlGraphics.Count; i < count; i++)
                {
                    m_tmpControlGraphic = m_controlGraphics[i];
                    UpdateColor(m_tmpControlGraphic.Control, m_tmpControlGraphic.Colors.Normal);
                }
                return;
            }

            UpdateColor(m_controlText.Control, m_controlText.Colors.Normal);
            UpdateColor(m_controlImage.Control, m_controlImage.Colors.Normal);
        }

        public override void onHover(bool isHovered)
        {
            if (AdvanceSetting)
            {
                for (int i = 0, count = m_controlGraphics.Count; i < count; i++)
                {
                    m_tmpControlGraphic = m_controlGraphics[i];

                    if (isHovered)
                        UpdateColor(m_tmpControlGraphic.Control, m_tmpControlGraphic.Colors.Hovered);
                    else
                        UpdateColor(m_tmpControlGraphic.Control, m_tmpControlGraphic.Colors.Normal);
                }
                return;
            }

            if (isHovered)
            {
                UpdateColor(m_controlText.Control, m_controlText.Colors.Hovered);
                UpdateColor(m_controlImage.Control, m_controlImage.Colors.Hovered);
            }
            else
            {
                UpdateColor(m_controlText.Control, m_controlText.Colors.Normal);
                UpdateColor(m_controlImage.Control, m_controlImage.Colors.Normal);
            }
        }

        public override void onSelected(bool isSelected)
        {
            if (AdvanceSetting)
            {
                for (int i = 0, count = m_controlGraphics.Count; i < count; i++)
                {
                    m_tmpControlGraphic = m_controlGraphics[i];
                    if (isSelected)
                        UpdateColor(m_tmpControlGraphic.Control, m_tmpControlGraphic.Colors.Selected);
                    else
                        UpdateColor(m_tmpControlGraphic.Control, m_tmpControlGraphic.Colors.Normal);
                }
                return;
            }

            if (isSelected)
            {
                UpdateColor(m_controlText.Control, m_controlText.Colors.Selected);
                UpdateColor(m_controlImage.Control, m_controlImage.Colors.Selected);
            }
            else
            {
                UpdateColor(m_controlText.Control, m_controlText.Colors.Normal);
                UpdateColor(m_controlImage.Control, m_controlImage.Colors.Normal);
            }
        }

        public override void onLocked(bool isLocked)
        {
            if (AdvanceSetting)
            {
                for (int i = 0, count = m_controlGraphics.Count; i < count; i++)
                {
                    m_tmpControlGraphic = m_controlGraphics[i];
                    UpdateColor(m_tmpControlGraphic.Control, m_tmpControlGraphic.Colors.Locked);
                }
                return;
            }

            UpdateColor(m_controlText.Control, m_controlText.Colors.Locked);
            UpdateColor(m_controlImage.Control, m_controlImage.Colors.Locked);
        }

        private void UpdateColor(Graphic control, Color color)
        {
            if (control == null)
                return;

            control.color = color;
        }
    }
}
