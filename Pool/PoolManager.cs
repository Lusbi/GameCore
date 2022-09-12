using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameCore;
using System;

namespace GameCore.Pool
{
    public class PoolManager : MonoSingleton<PoolManager> , IInitlization
    {
        private Dictionary<string, Queue<object>> m_cacheobjects = new Dictionary<string, Queue<object>>();
        private Dictionary<string, Queue<GameObject>> m_cacheObjects = new Dictionary<string, Queue<GameObject>>();

        public void Initlization(Action callBack = null)
        {
            m_cacheobjects.Clear();
            m_cacheObjects.Clear();
        }

        public T Get<T>() where T : class , new()
        {
            Type t = typeof(T); 
            string name = t.FullName;
            if (m_cacheobjects.ContainsKey(name) == false)
            {
                m_cacheobjects.Add(name, new Queue<object>());
            }

            if (m_cacheobjects[name].Count > 0)
            {
                return (T)m_cacheobjects[name].Dequeue();
            }
            else
            {
                return new T();
            }
        }

        public void Recycle<T>(T o)
        {
            Type t = o.GetType();
            string name = t.FullName;
            if (m_cacheobjects.ContainsKey(name) == false)
            {
                m_cacheobjects.Add(name, new Queue<object>());
            }

            m_cacheobjects[name].Enqueue(o);
        }

        public T Get<T>(GameObject reference) where T : Component
        {
            string name = reference.name;
            if (m_cacheObjects.ContainsKey(name) == false)
            {
                m_cacheObjects.Add(name, new Queue<GameObject>());
            }

            if (m_cacheObjects[name].Count > 0)
            {
                return m_cacheObjects[name].Dequeue().GetComponent<T>();
            }
            else
            {
                GameObject clone = GameObject.Instantiate(reference);
                clone.transform.localScale = Vector3.one;
                clone.transform.localPosition = Vector3.zero;

                return clone.GetComponent<T>();
            }
        }

        public void Recycle<T>(GameObject gameobject)
        {
            string name = gameobject.name;
            if (m_cacheObjects.ContainsKey(name) == false)
            {
                m_cacheObjects.Add(name, new Queue<GameObject>());
            }

            m_cacheObjects[name].Enqueue(gameobject);
        }

#if UNITY_EDITOR
        public void PoolManagerDetail()
        {
            string detailsString = string.Empty;
            foreach (string key in m_cacheobjects.Keys)
            {
                detailsString += $"{key} has Count : {m_cacheobjects[key].Count}\n";
            }
            Log.eLog.Error(detailsString);
        }
#endif
    }
}