namespace GameCore.Dialogue
{
    public class BoldEndCommand : ICommand
    {
        public void Do(ref GroupVariable groupVariable)
        {
            groupVariable.isBlod = false;
        }

        public void LoadParameter(string parameterValue)
        {
        }
    }
}