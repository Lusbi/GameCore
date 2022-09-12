using System.Collections.Generic;

public class CustomReplaceRule
{
    public const string CLASSNAME_TAG = "#ClassName";
    private Dictionary<string, string> m_rules = new Dictionary<string, string>();

    public string Replace(string text)
    {
        string result = text;
        foreach (string key in m_rules.Keys)
        {
            result = result.Replace(key, m_rules[key]);
        }
        return result;
    }

    public CustomReplaceRule Add(string rule , string value)
    {
        m_rules[rule] = value;
        return this;
    }

    public CustomReplaceRule Clear()
    {
        m_rules.Clear();
        return this;
    }

    public CustomReplaceRule SetClassName(string value)
    {
        Add(CLASSNAME_TAG, value);
        return this;
    }
}
