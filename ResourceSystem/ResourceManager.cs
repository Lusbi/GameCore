using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameCore.Resource
{
    public class ResourceManager : MonoSingleton<ResourceManager>
    {
        public void Load<T>(string name , Action<T> loadCallBack) where T : UnityEngine.Object
        {

        }
    }
}