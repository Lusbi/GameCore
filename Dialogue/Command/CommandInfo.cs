using GameCore.Pool;

namespace GameCore.Dialogue
{
    public class CommandInfo
    {
        public ICommand command;
        public string parameterValue;

        public void Parse(string content)
        {
            content = content.ToLower();
            if (content.Contains("{b}"))
            {
                command = PoolManager.instance.Get<BoldCommand>();
            }
            else if (content.Contains("{/b}"))
            {
                command = new BoldEndCommand();
            }
            else if (content.Contains("{i}"))
            {
                command = new ItalicCommand();
            }
            else if (content.Contains("{/i}"))
            {
                command = new ItalicEndCommand();
            }
            else if (content.Contains("color="))
            {
                command = new ColorCommand(); 
                SetParameterValue(content);
            }
            else if (content.Contains("{/color}"))
            {
                command = new ColorEndCommand();
            }
            else if (content.Contains("pause"))
            {
                command = new PauseCommand();
            }
            else if (content.Contains("refer"))
            {
                command = new ReferCommand();
                SetParameterValue(content);
            }
            else
            {
                command = new WriteTextCommand();
                parameterValue = content;
            }
            command.LoadParameter(parameterValue);
        }

        void SetParameterValue(string content)
        {
            int startIndex = content.IndexOf("=");
            parameterValue = content.Substring(startIndex, content.Length - startIndex);
        }
    }
}