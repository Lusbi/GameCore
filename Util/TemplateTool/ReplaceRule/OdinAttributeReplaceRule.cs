public class OdinAttributeReplaceRule : CustomReplaceRule
{
    public const string CUSTOMACTIONEDITOR_TYPENAME= "#originalClassName";

    public OdinAttributeReplaceRule SetOriginalClassName(string value)
    {
        Add(CUSTOMACTIONEDITOR_TYPENAME, value);
        return this;
    }
}
