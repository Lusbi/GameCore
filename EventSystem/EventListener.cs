using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameCore.Event
{
    public class EventListener
    {
        private Dictionary<Type, IDisposable> m_events;

        public EventListener()
        {
            m_events = new Dictionary<Type, IDisposable>();
        }

        ~EventListener()
        {
            Destory();
        }

        public void Add<T>(Action<T> action) where T : EventBase
        {
            Type type = typeof(T);
            if (m_events.ContainsKey(type))
            {
                return;
            }

            Action<T> newAction = (T eventData) =>
            {
                action?.Invoke(eventData);
            };

            m_events.Add(type, EventContainer<T>.Add(action));
        }

        public void Remove<T>() where T : EventBase
        {
            Type type = typeof(T);
            if (m_events.ContainsKey(type) == false)
            {
                return;
            }
            m_events[type].Dispose();
            m_events.Remove(type);
        }

        public void Destory()
        {
            foreach (IDisposable disposable in m_events.Values)
            {
                disposable.Dispose();
            }
            m_events.Clear();
        }
    }
}