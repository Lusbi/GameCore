using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GameCore.UI
{
    [RequireComponent(typeof(GraphicRaycaster))]
    public class UIManager : MonoSingleton<UIManager> , IInitlization
    {
        private GraphicRaycaster graphicRaycaster;
        private float m_updateTime = 0;
        private long m_stateID;
        private Dictionary<int, UIBase> m_registeredUIs = new Dictionary<int, UIBase>();

        private void Awake()
        {
            m_updateTime = Time.deltaTime;
            graphicRaycaster = GetComponent<GraphicRaycaster>();
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

        /// <summary>
        /// 控制介面是否可以點擊操作(全域)
        /// </summary>
        /// <param name="state"></param>
        public void SetGrahpicRaycaster(bool state)
        {
            graphicRaycaster.enabled = state;
        }
    }
}