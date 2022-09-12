using System;
using System.Collections.Generic;
using UnityEngine;

namespace GameCore.UI
{
    public class UIManager : MonoSingleton<UIManager> , IInitlization
    {
        private float m_updateTime = 0;
        private long m_stateID;
        private Dictionary<int, UIBase> m_registeredUIs = new Dictionary<int, UIBase>();

        private void Awake()
        {
            m_updateTime = Time.deltaTime;
        }

        public void Registered(UIBase uIBase)
        {
            if (m_registeredUIs.ContainsKey(uIBase.identifier))
            {
                return;
            }

            m_registeredUIs.Add(uIBase.identifier, uIBase);
        }
        public void UnRegistered(UIBase uIBase)
        {
            if (m_registeredUIs.ContainsKey(uIBase.identifier) == false)
            {
                return;
            }

            m_registeredUIs.Remove(uIBase.identifier);
        }

        public void Update()
        {
            foreach (UIBase uIBase in m_registeredUIs.Values)
            {
                uIBase.OnUpdate(m_updateTime);
            }
        }

        public void ChangeView(Enum e)
        {
            m_stateID = UIUtils.GetStateID(e);

            foreach (UIBase uIBase in m_registeredUIs.Values)
            {
                uIBase.Active( (uIBase.stateID & m_stateID) == m_stateID);
            }
        }

        public void Initlization(System.Action callBack = null)
        {
            m_updateTime = 0;
            m_registeredUIs.Clear();
        }
    }
}