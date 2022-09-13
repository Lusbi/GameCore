using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameCore;
using System;

public class FPSManager : MonoSingleton<FPSManager> , IInitlization
{
    public bool isLockFps = false;
    public float lockFPS = 60f;

    public float currentFps;

    private const float DEFAULT_TIME = 1000;
    private int m_currentCount = 0;

    private float m_lastTime = 0;
    public void Initlization(Action callBack = null)
    {
        m_currentCount = 0;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        m_currentCount++;
        if (m_currentCount >= DEFAULT_TIME)
        {
            currentFps = DEFAULT_TIME / (Time.time - m_lastTime);
            m_currentCount = 0;
            m_lastTime = Time.time;
        }
    }

    public float GetFps()
    {
        if (isLockFps)
        {
            return lockFPS;
        }
        return currentFps;
    }
}
