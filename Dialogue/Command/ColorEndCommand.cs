namespace GameCore.Dialogue
{
    public class ColorEndCommand : ICommand
    {
        public void Do(ref GroupVariable groupVariable)
        {
            groupVariable.isColor = false;
        }

        public void LoadParameter(string parameterValue)
        {
        }
    }
}