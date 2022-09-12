namespace GameCore.Dialogue
{
    public interface ICommand
    {
        void Do(ref GroupVariable groupVariable);

        void LoadParameter(string parameterValue);
    }
}