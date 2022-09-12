using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameCore
{
    public interface IInitlization
    {
        void Initlization(System.Action callBack = null);
    }
}