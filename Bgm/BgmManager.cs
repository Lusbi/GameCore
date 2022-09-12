using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameCore.Utils;
using DG.Tweening;

namespace GameCore.Bgm
{
    public class BgmManager : MonoSingleton<BgmManager>
    {
        private AudioSource m_audioSource;
        private Tweener m_tweener;
        private System.Action callBack = null;
        private void Awake()
        {
            m_audioSource = gameObject.AddComponentIfNull<AudioSource>();
            m_audioSource.volume = 0;
            m_audioSource.loop = true;
        }

        public void PlayBgm(AudioClip audioClip , float fadeInTime = 0 )
        {
            if (m_audioSource.clip == audioClip)
            {
                return;
            }
            m_audioSource.clip = audioClip;
            m_audioSource.Play();
            FadeIn(fadeInTime);
        }

        public void StopBgm(float fadeOutTime = 0)
        {
            FadeOut(fadeOutTime);
            callBack = ResetAudio;
        }

        private void FadeIn(float time)
        {
            m_tweener?.Kill();
            m_tweener = DOTween.To(OnUpdateAudioSFX, 0, 1, time).OnComplete(OnCallBack);
        }

        private void FadeOut(float time)
        {
            m_tweener?.Kill();
            m_tweener = DOTween.To(OnUpdateAudioSFX, m_audioSource.volume, 0, time).OnComplete(OnCallBack); ;
        }

        private void OnUpdateAudioSFX(float value)
        {
            m_audioSource.volume = value;
        }

        private void OnCallBack()
        {
            callBack?.Invoke();
            callBack = null;
        }

        private void ResetAudio()
        {
            m_audioSource.Stop();
            m_audioSource.clip = null;
        }
    }
}