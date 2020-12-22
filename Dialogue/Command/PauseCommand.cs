namespace GameCore.Dialogue
{
    public class PauseCommand : ICommand
    {
        public void Do(ref GroupVariable groupVariable)
        {
            groupVariable.isPause = true;
        }

        public void LoadParameter(string parameterValue)
        {
        }
    }
}