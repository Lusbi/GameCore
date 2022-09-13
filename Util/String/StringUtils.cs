using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameCore.Utils
{
    public static class StringUtils
    {
        public static int ToInt(this string value)
        {
            int result = 0;
            int.TryParse(value, out result);
            return result;
        }
        public static float ToFloat(this string value)
        {
            float result = 0;
            float.TryParse(value, out result);
            return result;
        }
        public static double ToDouble(this string value)
        {
            double result = 0;
            double.TryParse(value, out result);
            return result;
        }
        public static bool ToBool(this string value)
        {
            bool result = false;
            bool.TryParse(value, out result);
            return result;
        }
    }

    public static class StringArrayUtils
    {
        public enum FormatType
        {
            None,
            Csv,
            Tsv,
        }

        private static string[] row_format = new string[] { "\r\n" , "\r" , "\n"};
        private static string[] fields_csv_format = new string[] { "," };
        private static string[] fields_tsv_format = new string[] { "\t" };
        private static string[] fields_format = new string[] { ",","\t" };
        private static string pass_format = "//";

        public static string[] SplitToRow(this string value , StringSplitOptions stringSplitOptions = StringSplitOptions.RemoveEmptyEntries )
        {
            return value.Split(row_format, stringSplitOptions);
        }

        public static string[] SplitToField(this string value , FormatType formatType = FormatType.None , StringSplitOptions stringSplitOptions = StringSplitOptions.RemoveEmptyEntries)
        {
            switch (formatType)
            {
                case FormatType.Csv:
                    return value.Split(fields_csv_format, stringSplitOptions);
                case FormatType.Tsv:
                    return value.Split(fields_tsv_format, stringSplitOptions);
            }

            return value.Split(fields_format, stringSplitOptions);
        }

        public static bool IsMarks(this string value)
        {
            return value.Contains(pass_format);
        }
    }
}