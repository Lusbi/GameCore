using UnityEngine;
using UnityEngine.EventSystems;

namespace GameCore.UI
{
    public class UIEventListener : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
    {
        public delegate void VoidDelegate(GameObject go);
        public delegate void PositionDelegate(GameObject go, Vector2 position);

        public VoidDelegate onClick;
        public VoidDelegate onRightClick;
        public PositionDelegate onDown;
        public PositionDelegate onUp;
        public VoidDelegate onEnter;
        public VoidDelegate onExit;


        public static UIEventListener Get(GameObject obj)
        {
            UIEventListener listenerObj = obj.GetComponent<UIEventListener>();

            if (listenerObj == null)
            {
                listenerObj = obj.AddComponent<UIEventListener>();
            }
            return listenerObj;
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            if (eventData.pointerId == -1)
            {
                onClick?.Invoke(gameObject);
            }
            else
            {
                onRightClick?.Invoke(gameObject);
            }
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            onDown?.Invoke(gameObject, eventData.position);
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            onEnter?.Invoke(gameObject);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            onExit?.Invoke(gameObject);
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            onUp?.Invoke(gameObject, eventData.position);
        }

    }
}
