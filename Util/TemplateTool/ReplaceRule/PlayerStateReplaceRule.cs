public class PlayerStateReplaceRule : CustomReplaceRule
{
    private const string CATEGORY_TAG = "#category";
    private const string TOOLTIP_TAG = "#tooltip";

    public PlayerStateReplaceRule SetCategory(string value)
    {
        Add(CATEGORY_TAG, value);
        return this;
    }
    public PlayerStateReplaceRule SetToolTip(string value)
    {
        Add(TOOLTIP_TAG, value);
        return this;
    }
}
