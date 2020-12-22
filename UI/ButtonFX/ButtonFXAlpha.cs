using UnityEngine;

namespace GameCore.UI
{
    [AddComponentMenu("UI/ButtonFX/Alpha(CanvasGroup)"), RequireComponent(typeof(UIButton))]
    public class ButtonFXAlpha : ButtonFXBase
    {
        [SerializeField] private CanvasGroupSet canvasGroupSet = null;

        public override void onClickDown()
        {
            if (canvasGroupSet == null)
            {
                return;
            }

            if (canvasGroupSet.clicked != null)
            {
                canvasGroupSet.clicked.alpha = 1;
            }
        }

        public override void onClickUp()
        {
            if (canvasGroupSet == null)
            {
                return;
            }

            if (canvasGroupSet.clicked != null)
            {
                canvasGroupSet.clicked.alpha = 0;
            }
        }

        public override void onHover(bool isHovered)
        {
            if (canvasGroupSet == null)
            {
                return;
            }

            if (canvasGroupSet.hover != null)
            {
                canvasGroupSet.hover.alpha = isHovered ? 1 : 0;
            }
        }

        public override void onLocked(bool isLocked)
        {
            if (canvasGroupSet == null)
            {
                return;
            }

            if (canvasGroupSet.locked != null)
            {
                canvasGroupSet.locked.alpha = isLocked ? 1 : 0;
            }
        }

        public override void onSelected(bool isSelected)
        {
            if (canvasGroupSet == null)
            {
                return;
            }

            if (canvasGroupSet.selected != null)
            {
                canvasGroupSet.selected.alpha = isSelected ? 1 : 0;
            }
        }
    }
}
