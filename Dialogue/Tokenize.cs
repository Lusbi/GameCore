using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace GameCore.Dialogue
{
    public class Tokenize
    {
        private static List<string> prevTexts = new List<string>();
        public static List<string> tagTexts = new List<string>();
        public const string PATTERN = @"\{.*?\}";
        private static Regex regex = new Regex(PATTERN);
        private static Match match;
        
        public static List<CommandInfo> ParsersCommand(List<string> contents , bool debug = false)
        {
            List<CommandInfo> commands = new List<CommandInfo>();

            prevTexts.Clear();
            tagTexts.Clear();
            for (int i = 0, Count = contents.Count; i < Count; i++)
            {
                string content = contents[i];
                match = regex.Match(content);
                int index = 0;
                while (match.Success)
                {
                    string cacheString = content.Substring(index, match.Index - index);
                    prevTexts.Add(cacheString);
                    tagTexts.Add(match.Value);

                    commands.Add(GetCommand(cacheString));
                    commands.Add(GetCommand(match.Value));

                    index = match.Index + match.Value.Length;
                    match = match.NextMatch();
                }

                if (index < content.Length)
                {
                    string remainString = content.Substring(index, content.Length - index);
                    prevTexts.Add(remainString);
                    commands.Add(GetCommand(remainString));
                }

                commands.Add(GetPauseCommand());
            }

            return commands;
        }

        private static CommandInfo GetCommand(string content)
        {
            CommandInfo commandInfo = new CommandInfo();

            commandInfo.Parse(content);

            return commandInfo;
        }

        private static CommandInfo GetPauseCommand()
        {
            CommandInfo commandInfo = new CommandInfo();

            commandInfo.command = new PauseCommand();

            return commandInfo;
        }

        private static void Debug()
        {
            for (int i = 0 , Count = prevTexts.Count; i < Count; i ++)
            {
                GameCore.Log.eLog.Error("prevText:"+ prevTexts[i]);
            }

            for (int i = 0 , Count = tagTexts.Count; i < Count; i ++)
            {
                GameCore.Log.eLog.Error("tagTexts:" + tagTexts[i]);
            }
        }
    }
}