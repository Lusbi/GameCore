namespace GameCore.Dialogue
{
    public class ItalicCommand : ICommand
    {
        public void Do(ref GroupVariable groupVariable)
        {
            groupVariable.isItalic = true;
        }

        public void LoadParameter(string parameterValue)
        {
        }
    }
}