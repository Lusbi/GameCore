using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameCore.Pool;
using GameCore.Dialogue;

public class PoolDemoScript : MonoBehaviour
{
    public bool demoIt = false;
    private PoolManager m_poolManager;
    private List<object> m_caches = new List<object>();
    private void Awake()
    {
        m_poolManager = PoolManager.instance;
        m_caches.Clear();
    }

    public void OnValidate()
    {
        if (Application.isPlaying == false)
        {
            return;
        }
        if (demoIt == false)
        {
            return;
        }

        demoIt = false;
        CreateCommand();
        Recycle();
        m_poolManager.PoolManagerDetail();
    }

    private void CreateCommand()
    {
        for (int i = 0; i < 100; i++)
        {
            int value = Random.Range(1, 10);
            switch (value)
            {
                case 1:
                    m_caches.Add(m_poolManager.Get<BoldCommand>());
                    break;
                case 2:
                    m_caches.Add(m_poolManager.Get<BoldEndCommand>());
                    break;
                case 3:
                    m_caches.Add(m_poolManager.Get<ColorCommand>());
                    break;
                case 4:
                    m_caches.Add(m_poolManager.Get<ColorEndCommand>());
                    break;
                case 5:
                    m_caches.Add(m_poolManager.Get<ItalicCommand>());
                    break;
                case 6:
                    m_caches.Add(m_poolManager.Get<ItalicEndCommand>());
                    break;
                case 7:
                    m_caches.Add(m_poolManager.Get<PauseCommand>());
                    break;
                case 8:
                    m_caches.Add(m_poolManager.Get<ReferCommand>());
                    break;
                case 9:
                    m_caches.Add(m_poolManager.Get<ResetCommand>());
                    break;
            }
        }
    }

    private void Recycle()
    {
        for (int i = m_caches.Count -1; i>= 0; i--)
        {
            m_poolManager.Recycle(m_caches[i]);
            m_caches.RemoveAt(i);
        }    
    }
}
