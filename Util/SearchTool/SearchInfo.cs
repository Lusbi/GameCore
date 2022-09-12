using System;

namespace Utils.Editor
{
    [Serializable]
    public class SearchInfo
    {
        public string searchName;
        public Type type;

        public virtual void Setup(Type type)
        {
            this.type = type;
            searchName = type.Name;
        }
    }
}