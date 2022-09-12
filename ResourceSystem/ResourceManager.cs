using System;
using System.Collections;
using UnityEngine;

namespace GameCore.Resource
{
    public class ResourceManager : MonoSingleton<ResourceManager>
    {
        public void LoadAsync<T>(string assetName, Action<T> callback) where T : UnityEngine.Object
        {
            StartCoroutine(CoroutineLoadAsync<T>(assetName, callback));
        }

        public void LoadAsync<T>(string assetName, Action<T, object> callback, object data) where T : UnityEngine.Object
        {
            StartCoroutine(CoroutineLoadAsync<T>(assetName, callback, data));
        }

        private IEnumerator CoroutineLoadAsync<T>(string assetName, Action<T> callback) where T : UnityEngine.Object
        {
            if (CheckAssetName(assetName) == false)
            {
                callback?.Invoke(null);
                yield break;
            }

            ResourceRequest resourceRequest = Resources.LoadAsync<T>(assetName);
            while (resourceRequest.isDone == false)
            {
                yield return null;
            }

            callback?.Invoke((T)resourceRequest.asset);
        }

        private IEnumerator CoroutineLoadAsync<T>(string assetName, Action<T, object> callback, object data) where T : UnityEngine.Object
        {
            if (CheckAssetName(assetName) == false)
            {
                callback?.Invoke(null, null);
                yield break;
            }

            ResourceRequest resourceRequest = Resources.LoadAsync<T>(assetName);
            while (resourceRequest.isDone == false)
            {
                yield return null;
            }

            callback?.Invoke((T)resourceRequest.asset, data);
        }

        private bool CheckAssetName(string assetName)
        {
            if (string.IsNullOrEmpty(assetName))
            {
                return false;
            }

            return true;
        }
    }
}