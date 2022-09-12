namespace GameCore.Dialogue
{
    public class BoldCommand : ICommand
    {
        public void Do(ref GroupVariable groupVariable)
        {
            groupVariable.isBlod = true;
        }

        public void LoadParameter(string parameterValue)
        {
            
        }
    }
}