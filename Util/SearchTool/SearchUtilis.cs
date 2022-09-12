using System;
using System.Collections.Generic;
using System.Reflection;
using Utils.Editor;

public class SearchUtilis
{
    private static Assembly[] assemblies;

    private static void Cache()
    {
        if (assemblies == null)
        {
            assemblies = AppDomain.CurrentDomain.GetAssemblies();
        }
    }

    public static List<T> SearchSubClass<T>(params Type[] searchTypes) where T : SearchInfo , new()
    {
        Cache();
        List<T> searchInfos = new List<T>();
        for (int i = 0, assmbliesCount = assemblies.Length; i < assmbliesCount; i++)
        {
            try
            {
                Type[] types = assemblies[i].GetTypes();
                for (int j = 0, Count = types.Length; j < Count; j++)
                {
                    bool isCompare = true;
                    foreach (Type type in searchTypes)
                    {
                        if (!types[j].IsSubclassOf(type))
                        {
                            isCompare = false;
                            break;
                        }
                    }
                    if (isCompare)
                    {
                        T t = new T();
                        t.Setup(types[j]);
                        searchInfos.Add(t);
                    }
                }
            }
            catch { }
        }
        return searchInfos;
    }

    public static List<T> SearchSubClass<T>(params string[] typeNames) where T : SearchInfo , new()
    {
        Type[] types = new Type[typeNames.Length];
        for (int i = 0 , Count = types.Length; i < Count; i ++)
        {
            types[i] = Type.GetType(typeNames[i]);
        }
        return SearchSubClass<T>(types);
    }
}
