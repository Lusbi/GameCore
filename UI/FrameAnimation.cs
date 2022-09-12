using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GameCore.UI
{
    [RequireComponent(typeof(Image))]
    public class FrameAnimation : MonoBehaviour
    {
        [Serializable]
        public class FrameInfo
        {
            public Sprite sprite;

            public float time;
        }

        [SerializeField]
        private Image m_image = null;

        private List<FrameInfo> m_frameInfos = new List<FrameInfo>();

        public bool autoPlay;
        public bool loop;
        public bool playing { get; private set; } = false;

        private float m_timeCount = 0;
        private int m_indexCount = 0;

        private void OnEnable()
        {
            if (m_image != null)
            {
                m_image.enabled = true;
            }

            if (autoPlay)
            {
                Play();
            }
        }

        private void OnDisable()
        {
            Stop();
            if (m_image != null)
            {
                m_image.enabled = false;
            }
        }

        private void Update()
        {
            if (!playing || m_frameInfos.Count <= 0)
            {
                return;
            }

            if (m_indexCount >= m_frameInfos.Count)
            {
                if (loop)
                {
                    Play();
                    return;
                }

                Stop();
            }

            if (m_timeCount >= m_frameInfos[m_indexCount].time)
            {
                m_timeCount = 0;
                m_indexCount++;
                if (m_indexCount < m_frameInfos.Count)
                {
                    m_image.sprite = m_frameInfos[m_indexCount].sprite;
                }
            }

            m_timeCount += Time.deltaTime;
        }

        public void Play()
        {
            if (m_frameInfos.Count <= 0)
            {
                return;
            }

            m_timeCount = 0;
            m_indexCount = 0;
            m_image.sprite = m_frameInfos[m_indexCount].sprite;
            playing = true;
        }

        public void Stop()
        {
            playing = false;
        }

        public void Clear()
        {
            if (m_image == null || m_frameInfos.Count <= 0)
            {
                return;
            }

            m_image.sprite = m_frameInfos[0].sprite;
        }
    }
}
