using System;

namespace GameCore.Event
{
    public class EventManager : Singleton<EventManager>
    {
        public void Add<T>(Action<T> action) where T : EventBase
        {
            EventContainer<T>.Add(action);
        }
        public void Remove<T>(Action<T> action) where T : EventBase
        {
            EventContainer<T>.Remove(action);
        }
        public void Send<T>() where T : EventBase
        {
            EventContainer<T>.Send();
        }
        public void Send<T>(T eventBase) where T : EventBase
        {
            EventContainer<T>.Send(eventBase);
        }
    }
}