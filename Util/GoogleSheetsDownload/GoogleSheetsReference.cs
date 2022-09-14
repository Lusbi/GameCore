#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils.Editor;

namespace GameCore.GoogleSheets
{
    [System.Serializable]
    public class GoogleSheetsReference : ISerializationCallbackReceiver
    {
        private static Dictionary<string, string> m_googleSheetsReferences;
        private static Dictionary<string, string> googleSheetsReferences
        {
            get
            {
                if (m_googleSheetsReferences == null)
                {
                    m_googleSheetsReferences = new Dictionary<string, string>(10);
                }
                return m_googleSheetsReferences;
            }
        }

        public string title;
        public string url;

        public GoogleSheetsDownloader googleSheetsDownloader { get; private set; }

        private bool hasTitle
        {
            get { return !string.IsNullOrEmpty(title); }
        }

        private bool hasUrl
        {
            get { return !string.IsNullOrEmpty(url); }
        }

        public void OnBeforeSerialize()
        {
            if (googleSheetsReferences.ContainsKey(title))
            {
                return;
            }
            if (hasTitle && hasUrl)
            {
                Create();
            }
        }

        public void OnAfterDeserialize()
        {
            if (googleSheetsReferences.ContainsKey(title))
            {
                googleSheetsReferences.Remove(title);
            }
        }

        public GoogleSheetsReference(GoogleSheetsReference googleSheetsReference)
        {
            title = googleSheetsReference.title;
            url = googleSheetsReference.url;
            if (hasTitle && hasUrl)
            {
                Create();
            }
        }

        ~GoogleSheetsReference()
        {
            Delete();
        }

        public bool needCreate
        {
            get { return !string.IsNullOrEmpty(title) && !googleSheetsReferences.ContainsKey(title); }
        }

        private void Create()
        {
            if (!googleSheetsReferences.ContainsKey(title))
            {
                googleSheetsReferences.Add(title, url);
            }
        }

        private void Delete()
        {
            googleSheetsReferences.Remove(title);

            title = string.Empty;
            url = string.Empty;
        }

        private void ModifyUrl()
        {
            if (googleSheetsReferences.ContainsKey(title))
            {
                googleSheetsReferences[title] = url;
            }
        }

        #region API
        public void Download(System.Action onFinished)
        {
            if (googleSheetsDownloader == null)
            {
                googleSheetsDownloader = new GoogleSheetsDownloader(url).OnComplete(onFinished).Download();
            }
            else
            {
                onFinished?.Invoke();
            }
        }
        #endregion
    }
}
#endif