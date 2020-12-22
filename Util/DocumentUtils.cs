using System;
using System.IO;
using UnityEditor;
using System.Text;

namespace GameCore.Utils
{
    public static class DocumentUtils
    {
#if UNITY_EDITOR
        /// <summary>
        /// 資料輸出
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="stringBuilder"></param>
        public static void Export(string fileName , StringBuilder stringBuilder)
        {
            string path = "";
            path = EditorUtility.OpenFolderPanel("選擇輸出地點", path, "");

            CreateStreamWriter(path , fileName, stringBuilder);

            System.Diagnostics.Process.Start(path);
        }

        /// <summary>
        /// 資料輸入
        /// </summary>
        /// <returns></returns>
        public static StreamReader Import()
        {
            string path = "";
            path = EditorUtility.OpenFilePanel("選擇文件", path, ".csv");

            return LoadStreamReader(path);
        }

        private static void CreateStreamWriter(string path , string fileName, StringBuilder stringBuilder)
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
#endif
    }
}