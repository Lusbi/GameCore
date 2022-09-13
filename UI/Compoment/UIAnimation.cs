using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIAnimation : MonoBehaviour
{
    public Image image_self;
    public Sprite[] gifSources;
    public float frame = 1;
    public bool enablePlay = true;

    [SerializeField] private int m_curFrame;
    [SerializeField] private int m_curIndex = 0;
    [SerializeField] private bool isPlaying = false;

    private void OnEnable()
    {
        ResetAnimation();

        isPlaying = enablePlay;
    }

    public void ResetAnimation()
    {
        if (image_self == null)
        {
            image_self = GetComponent<Image>();
        }
        m_curIndex = 0;
        m_curFrame = 0;

        UpdateSpriteIndex(0);
    }

    private void Update()
    {
        if (isPlaying == false)
        {
            return;
        }
        if (m_curFrame > frame)
        {
            NextSprite();
            m_curFrame = 0;
        }
        else
        {
            m_curFrame++;
        }
    }

    public void UpdateState(bool state)
    {
        isPlaying = state;
    }

    public void EnableState(bool state)
    {
        enabled = state;
        enablePlay = state;
        if (enablePlay)
        {
            isPlaying = state;
        }
        else
        {
            isPlaying = state || false;
        }
    }

    private void NextSprite()
    {
        m_curIndex = (m_curIndex +1) % gifSources.Length;

        UpdateSpriteIndex(m_curIndex);
    }

    private void UpdateSpriteIndex(int index)
    {
        if (gifSources == null || image_self == null)
        {
            return;
        }

        image_self.sprite = gifSources.Length > 0 ? gifSources[index] : null;
        image_self.enabled = image_self.sprite != null;
    }
}
