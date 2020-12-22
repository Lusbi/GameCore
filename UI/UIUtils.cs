using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameCore.UI
{
    public class UIUtils
    {
        public const float DESIGNER_WIDTH = 1920f;
        public const float DESIGNER_HEIGHT = 1080f;
        public readonly Vector2 DESIGNER_SIZE = new Vector2(DESIGNER_HEIGHT, DESIGNER_WIDTH);

        public static long GetStateID(params Enum[] enums)
        {
            long stateId = 0;

            foreach (Enum e in enums)
            {
                stateId |= GetEnumStateId(e);
            }
            return stateId;
        }
        private static long GetEnumStateId(Enum value)
        {
            return 1 << Convert.ToInt32(value);
        }
        public static long GetAllStateId<T>() where T : struct, IConvertible
        {
            T[] enumValues = (T[])Enum.GetValues(typeof(T));
            long stateId = 0;

            foreach (T t in enumValues)
            {
                stateId |= GetEnumStateId(t);
            }
            
            return stateId;
        }
        private static long GetEnumStateId<T>(T value) where T : struct, IConvertible
        {
            return 1 << Convert.ToInt32(value);
        }
    }
}