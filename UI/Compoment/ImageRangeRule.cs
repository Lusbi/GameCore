using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageRangeRule : MonoBehaviour
{
    private Image m_image;

    public bool alphaThreshold = true;

    private void Awake()
    {
        m_image = GetComponent<Image>();
        if (alphaThreshold)
        {
            m_image.alphaHitTestMinimumThreshold = 0.5f;
        }
        else
        {
            m_image.alphaHitTestMinimumThreshold = 1f;
        }
    }
}
