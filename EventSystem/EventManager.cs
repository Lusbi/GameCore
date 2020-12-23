using System;
using System.Collections.Generic;

namespace GameCore.Event
{
    public class EventManager : Singleton<EventManager>
    {
        private Dictionary<Type, EventBase> m_eventListeners = new Dictionary<Type, EventBase>();

        public void AddListener<T>(Action<T> listener) where T : EventBase
        {
            Type t = typeof(T);
            if (m_eventListeners.ContainsKey(t) == false)
            {
                m_eventListeners.Add(t, new EventContainer<T>());
            }

            ((EventContainer<T>)m_eventListeners[t]).AddListener(listener);
        }

        public void RemoveListener<T>(Action<T> listener) where T : EventBase
        {
            Type t = typeof(T);
            if (m_eventListeners.ContainsKey(t))
            {
                ((EventContainer<T>)m_eventListeners[t]).RemoveListener(listener);
            }
        }

        public void Send<T>() where T : EventBase
        {
            Send(default(T));
        }

        public void Send<T>(T eventData) where T : EventBase
        {
            Type t = typeof(T);
            if (m_eventListeners.ContainsKey(t))
            {
                ((EventContainer<T>)m_eventListeners[t]).Send(eventData);
            }
        }
    }
}