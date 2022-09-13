using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameCore.Event
{
    public static class EventContainer<T> where T : EventBase
    {
        private static Action<T> m_events;

        public static IDisposable Add(Action<T> action)
        {
            m_events += action;
            return new EventListenerDispose(action);
        }

        public static void Remove(Action<T> action)
        {
            m_events -= action;
        }

        public static void Send()
        {
            Send(null);
        }
        public static void Send(T eventData)
        {
            m_events?.Invoke(eventData);
        }

        private class EventListenerDispose : IDisposable
        {
            public Action<T> action;

            public EventListenerDispose(Action<T> action)
            {
                this.action = action;
            }

            public void Dispose()
            {
                Remove(action);
            }
        }

    }
}