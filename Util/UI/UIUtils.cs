using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GameCore;

public static class UIUtils 
{
    public static Image SetImage(this Image image , Sprite sprite)
    {
        if (image == null)
        {
            return image ;
        }

        image.sprite = sprite;
        return image;
    }

    public static Image SetColor(this Image image,Color color)
    {
        if (image == null)
        {
            return image;
        }
        if (image.enabled == false)
        {
            return image;
        }

        image.color = color;
        return image;
    }

    public static Image SetConditionColor(this Image image , bool condition , Color trueColor , Color falseColor)
    {
        if (image == null)
        {
            return image;
        }

        image.color = condition ? trueColor : falseColor;

        return image;
    }

    public static Image AutoEnable(this Image image)
    {
        if (image == null)
        {
            return image;
        }

        image.enabled = image.sprite != null;

        return image;
    }

    public static CanvasGroup CanvasState(this CanvasGroup canvasGroup , bool state , bool raycastUpdate = true)
    {
        canvasGroup.alpha = state ? 1 : 0;
        if (raycastUpdate)
        {
            canvasGroup.blocksRaycasts = state;
        }
        return canvasGroup;
    }
}
