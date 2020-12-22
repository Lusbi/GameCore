namespace GameCore.Dialogue
{
    public class ItalicEndCommand : ICommand
    {
        public void Do(ref GroupVariable groupVariable)
        {
            groupVariable.isItalic = false;
        }

        public void LoadParameter(string parameterValue)
        {
        }
    }
}