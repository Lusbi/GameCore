using GameCore.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ButtonUtils
{
    public static void AddOnClick(this UIButton uIButton , System.Action<UIButton> clickAction)
    {
        uIButton.onClicked = clickAction;
    }
    
    public static void RemoveOnClick(this UIButton uIButton )
    {
        uIButton.onClicked = null;
    }

    public static void AddOnHover(this UIButton uIButton , System.Action<UIButton , bool> hoverAction)
    {
        uIButton.onHover = hoverAction;
    }

    public static void RemoveOnHover(this UIButton uIButton)
    {
        uIButton.onHover = null;
    }
}
