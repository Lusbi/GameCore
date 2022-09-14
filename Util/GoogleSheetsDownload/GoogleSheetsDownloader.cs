#if UNITY_EDITOR
using System.Collections;
using System.Text.RegularExpressions;
using Unity.EditorCoroutines.Editor;
using UnityEngine.Networking;
using UnityEditor;
using System;
using System.Text;
using System.IO;
using UnityEngine;

namespace GameCore.GoogleSheets
{
    public class GoogleSheetsDownloader
    {
        private const string DOWNLOADER_FORMAT = "https://docs.google.com/spreadsheet/ccc?key={0}&gid={1}&usp=sharing&output=csv";
        private const string REGULAR_PATTERN = "\\d\\w*";

        public string url { get; private set; }
        public string key { get; private set; }
        public string gid { get; private set; }
        public string downloaderUrl { get; private set; }
        public string text { get { return cacheStringBuilder.ToString(); } }

        private StringBuilder cacheStringBuilder = new StringBuilder();
        private Action m_onComplete;

        public bool IsDownloaded
        {
            get { return cacheStringBuilder.Length > 0; }
        }

        public GoogleSheetsDownloader(string url)
        {
            this.url = url;

            MatchCollection matchCollection = Regex.Matches(url, REGULAR_PATTERN);
            if (matchCollection != null && matchCollection.Count > 1)
            {
                key = GetMatchValue(matchCollection[0]);
                gid = GetMatchValue(matchCollection[1]);
            }

            if (string.IsNullOrEmpty(key) || string.IsNullOrEmpty(gid))
            {
                return;
            }

            downloaderUrl = string.Format(DOWNLOADER_FORMAT, key, gid);
        }

        public GoogleSheetsDownloader Save(string outputPath)
        {
            if (IsDownloaded)
            {
                string writerName = outputPath;
                using (StreamWriter writer = new StreamWriter(writerName, false, Encoding.Unicode))
                {
                    writer.Write(cacheStringBuilder.ToString());
                }
            }
            return this;
        }

        public GoogleSheetsDownloader Release()
        {
            cacheStringBuilder.Length = 0;
            url = string.Empty;
            key = string.Empty;
            gid = string.Empty;
            downloaderUrl = string.Empty;
            m_onComplete = null;
            return this;
        }

        public GoogleSheetsDownloader OnComplete(Action onComplete)
        {
            m_onComplete = onComplete;
            return this;
        }

        public GoogleSheetsDownloader Download()
        {
            EditorCoroutineUtility.StartCoroutine(Downloading(), this);
            return this;
        }

        private string GetMatchValue(Match match)
        {
            if (match.Success)
            {
                return match.Value;
            }
            return string.Empty;
        }

        private IEnumerator Downloading()
        {
            UnityWebRequest unityWebRequest = UnityWebRequest.Get(downloaderUrl);
            unityWebRequest.SendWebRequest();

            while (!unityWebRequest.isDone)
            {
                EditorUtility.DisplayCancelableProgressBar("Downloader", downloaderUrl, unityWebRequest.downloadProgress);
                yield return null;
            }

            cacheStringBuilder.Clear();
            if (string.IsNullOrEmpty(unityWebRequest.error))
            {
                cacheStringBuilder.Append(unityWebRequest.downloadHandler.text);
            }
            else
            {
                cacheStringBuilder.Append("Error.");
            }
            Debug.Log(text);
            m_onComplete?.Invoke();
            EditorUtility.ClearProgressBar();
        }
    }
}
#endif