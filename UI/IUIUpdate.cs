using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameCore.UI
{
    public interface IUIUpdate
    {
        void OnUIUpdate(float time);
    }
}