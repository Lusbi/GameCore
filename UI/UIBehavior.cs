using DG.Tweening;
using GameCore.Resource;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameCore.UI
{
    public class UIBehavior<T> : UIBase where T : UIViewBase
    {
        protected virtual string view_path { get; }
        protected virtual int sortOrderID { get; }

        protected T m_viewTemplate;
        protected T m_view;
        protected System.Action m_callBack;

        public UIBehavior(System.Action callBack = null, params System.Enum[] enums)
        {
            identifier = GetHashCode();
            stateID = UIUtils.GetStateID(enums);
            m_callBack = callBack;
            ResourceManager.instance.LoadAsync<T>(view_path, ViewLoaded);
        }

        public virtual void ViewLoaded(T uIViewBase)
        {
            m_viewTemplate = uIViewBase;

            m_view = GameObject.Instantiate(m_viewTemplate);
            m_view.Initlization();
            m_view.transform.SetParent(UIManager.instance.transform);
            m_view.transform.localPosition = Vector3.zero;
            m_view.transform.localScale = Vector3.one;

            m_view.canvasGroup.alpha = 0;
            m_view.canvasGroup.blocksRaycasts = false;

            ViewLoadedFinished();
        }

        public virtual void ViewLoadedFinished()
        {
            UIManager.instance.Registered(this);

            // 設定層級
            m_view.Initlization();
            m_view.SetSortOrder(sortOrderID);

            m_callBack?.Invoke();

            if (m_view.currentStatus != UIStatus.Enable)
            {
                m_view.Active(false);
            }
        }

        public override void Destory()
        {
            GameObject.Destroy(m_view.gameObject);
            m_view = null;
        }

        public override void Active(bool isActive)
        {
            m_view.Active(isActive);
        }

        public virtual void ViewEnable()
        {
            m_view.ViewEnable();
        }

        public virtual void ViewDisable()
        {
            m_view.ViewDisable();
        }

    }
}