using UnityEngine;
using DG.Tweening;
using System;

namespace GameCore.UI
{
    public class UIBase : IInitlization
    {
        public long stateID;
        public int identifier;

        public virtual void OnUpdate(float time) { }

        public virtual void Destory()
        {
            UIManager.instance.UnRegistered(this);
        }

        public virtual void Initlization(Action callBack = null)
        {
            
        }

        public virtual void Active(bool active)
        {
            
        }
    }
}