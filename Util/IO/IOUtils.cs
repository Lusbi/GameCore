#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEditor;
using UnityEngine;

namespace GameCore.Utils
{
    public static class IOUtils
    {
        public static class Document
        {
            private const string DOCUMENT_EXPORT_LASTPATH = "DocumentExportLastPath";
            private const string DOCUMENT_IMPORT_LASTPATH = "DocumentImportLastPath";

            /// <summary>
            /// 資料輸出
            /// </summary>
            /// <param name="fileName"></param>
            /// <param name="stringBuilder"></param>
            public static void Export(string fileName, StringBuilder stringBuilder)
            {
                string path = EditorPrefs.GetString(DOCUMENT_EXPORT_LASTPATH); ;
                path = EditorUtility.OpenFolderPanel("選擇輸出地點", path, "");
                CreateStreamWriter(path, fileName, stringBuilder);

                System.Diagnostics.Process.Start(path);

                EditorPrefs.SetString(DOCUMENT_EXPORT_LASTPATH, path);
            }

            /// <summary>
            /// 資料輸入
            /// </summary>
            /// <returns></returns>
            public static StreamReader Import()
            {
                string path = EditorPrefs.GetString(DOCUMENT_IMPORT_LASTPATH);
                path = EditorUtility.OpenFilePanel("選擇文件", path, ".csv");
                EditorPrefs.SetString(DOCUMENT_IMPORT_LASTPATH , path);

                return LoadStreamReader(path);
            }

            private static void CreateStreamWriter(string path, string fileName, StringBuilder stringBuilder)
            {
                string outPutPath = path + "/" + fileName + ".csv";
                using (StreamWriter writer = new StreamWriter(outPutPath, false, Encoding.UTF8))
                {
                    writer.Write(stringBuilder.ToString());
                    writer.WriteLine();
                }
            }

            private static StreamReader LoadStreamReader(string path)
            {
                StreamReader reader = new StreamReader(path);
                return reader;
            }
        }

        public static class Folder
        {
            /// <summary>
            /// 應用於 unity 內創建資料夾的方法，創建成功時回傳資料夾路徑
            /// -> 父資料夾位置從 Assets 開始
            /// </summary>
            /// <param name="parentFolderName"></param>
            /// <param name="folderName"></param>
            /// <returns></returns>
            public static string Create(string parentFolderName , string folderName)
            {
                if (string.IsNullOrEmpty(folderName))
                {
                    Debug.LogError("[建立資料夾錯誤] 沒有提供資料夾名稱，無法建立。");
                    return string.Empty;
                }
                string folderGuid = string.Empty;
                string validFolderPath = Path.Combine(parentFolderName, folderName);
                if (AssetDatabase.IsValidFolder(validFolderPath))
                {
                    return validFolderPath;
                }
                else
                {
                    folderGuid = AssetDatabase.CreateFolder(parentFolderName, folderName);
                }

                if (folderGuid.Length <=0)
                {
                    return string.Empty;
                }

                return AssetDatabase.GUIDToAssetPath(folderGuid);
            }

            public static void Remove(string folderPath)
            {
                AssetDatabase.DeleteAsset(folderPath);
            }

            public static bool Create(string folderName)
            {
                if (string.IsNullOrEmpty(folderName))
                {
                    Debug.LogError("[建立資料夾錯誤] 沒有提供資料夾名稱，無法建立。");
                    return false;
                }

                if (Directory.Exists(folderName))
                {
                    return false;
                }

                Directory.CreateDirectory(folderName);

                return true;
            }
        }
    }
}
#endif