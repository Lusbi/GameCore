using UnityEngine;
using GameCore.Event;
using Sirenix.OdinInspector;

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

#if ODIN_INSPECTOR
    [Button("事件A 發送") ,ShowIf("isAppling")]
#endif
    private void DemoAEvent()
    {
        EventManager.instance.Send(new EventListenerDemoA());
    }

#if ODIN_INSPECTOR
    [Button("事件B 發送"), ShowIf("isAppling")]
#endif
    private void DemoBEvent()
    {
        EventManager.instance.Send(new EventListenerDemoB(Log));
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
