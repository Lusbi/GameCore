namespace GameCore.Dialogue
{
    public class ResetCommand : ICommand
    {
        public void Do(ref GroupVariable groupVariable)
        {
            groupVariable.Initialization();
        }

        public void LoadParameter(string parameterValue)
        {

        }
    }
}