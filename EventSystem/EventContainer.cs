using System;

namespace GameCore.Event
{
    public class EventContainer<T> : EventBase
    {
        protected Action<T> m_listener;

        public void  AddListener(Action<T> listener)
        {
            m_listener += listener;
        }

        public void RemoveListener(Action<T> listener)
        {
            m_listener -= listener;
        }

        public void Send(T eventData)
        {
            m_listener?.Invoke(eventData);
        }
    }
}