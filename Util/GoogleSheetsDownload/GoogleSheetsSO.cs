using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameCore.GoogleSheets;
using System;
using GameCore.Log;

[System.Serializable]
public class GoogleSheetsPackage
{
    public bool enable;
    public string title;
    public string url;

    public GoogleSheetsDownloader googleSheetsDownloader;

    public void Download(Action onComplete = null)
    {
        googleSheetsDownloader = new GoogleSheetsDownloader(url);
        googleSheetsDownloader.OnComplete(onComplete).Download();
    }
}

[CreateAssetMenu(fileName = "GoogleSheets_Reference" , menuName = "Editor Tool/���ݤU���]�w��")]
public class GoogleSheetsSO : ScriptableObject
{
    public List<GoogleSheetsPackage> googleSheetsPackages = new List<GoogleSheetsPackage>();
    private int m_waiitCount = 0;

    public string Get(string key)
    {
        foreach (GoogleSheetsPackage googleSheetsPackage in googleSheetsPackages)
        {
            if (googleSheetsPackage.title.Equals(key))
            {
                return googleSheetsPackage.googleSheetsDownloader.text;
            }
        }
        return string.Empty;
    }

    public void Download()
    {
        m_waiitCount = googleSheetsPackages.Count;
        Debug.LogError($"������ {this.name} �`�ƶq���G{m_waiitCount}");
        foreach (GoogleSheetsPackage googleSheetsPackage in googleSheetsPackages)
        {
            if (googleSheetsPackage == null)
            {
                m_waiitCount--;
                continue;
            }
            if (googleSheetsPackage.enable == false)
            {
                m_waiitCount--;
                continue;
            }
            googleSheetsPackage.Download(Finished);
        }
    }

    private void Finished()
    {
        m_waiitCount--;
        Debug.LogError($"������ {this.name} �Ѿl�U���ƶq�G{m_waiitCount}");
    }
}
