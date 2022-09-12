namespace GameCore.Dialogue
{
    public class ColorCommand : ICommand
    {
        private string colorParameterValue;

        public void Do(ref GroupVariable groupVariable)
        {
            groupVariable.isColor = true;

            int startIndex = colorParameterValue.IndexOf("=");
            groupVariable.cacheDialogue = string.Format("<color{0}>" , colorParameterValue.Substring(startIndex, colorParameterValue.Length -1 - startIndex));
        }

        public void LoadParameter(string parameterValue)
        {
            colorParameterValue = parameterValue;
        }
    }
}