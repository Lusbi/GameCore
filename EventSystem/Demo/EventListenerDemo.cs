using UnityEngine;
using GameCore.Event;

public class EventListenerDemoA : EventBase
{

}

public class EventListenerDemoB : EventBase
{
    public string log;
    public EventListenerDemoB(string log)
    {
        this.log = log;
    }
}

public class EventListenerDemo : MonoBehaviour
{
    public string Log;
    public bool isAppling
    {
        get { return Application.isPlaying; }
    }

    private void Start()
    {
        EventManager.instance.AddListener<EventListenerDemoA>(OnListenerDemoA);
        EventManager.instance.AddListener<EventListenerDemoB>(OnListenerDemoB);
    }

    private void OnListenerDemoB(EventListenerDemoB obj)
    {
        Debug.Log($"This is DemoB -> Log {obj.log}");
    }

    private void OnListenerDemoA(EventListenerDemoA obj)
    {
        Debug.Log("This is DemoA");
    }
}
