using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GameCore.Dialogue
{
    public class Dialogue : IRegisteredEvent
    {
        private Text uiText;

        private GroupVariable groupVariable = new GroupVariable();
        private int currentIndex = 0;

        private List<CommandInfo> commands = new List<CommandInfo>();

        public bool isDialoguing
        {
            get
            {
                return groupVariable.currentCommandEnd == false;
            }
        }
        public Dialogue Initialization()
        {
            groupVariable.Initialization();
            uiText = null;
            currentIndex = 0;
            return this;
        }

        public Dialogue SetDialogue(Text uiText)
        {
            this.uiText = uiText;
            this.uiText.text = string.Empty;
            return this;
        }

        public Dialogue ParseCommands(List<string> originalContents)
        {
            commands = Tokenize.ParsersCommand(originalContents);
            return this;
        }

        public void Update(float time)
        {
            if (currentIndex < commands.Count)
            {
                commands[currentIndex].command.Do(ref groupVariable);

                if (groupVariable.currentCommandEnd && groupVariable.isPause == false)
                {
                    NextDialogueCommand();
                }
            }
            UpdateUI();
        }

        public void UpdateUI()
        {
            if (uiText == null)
            {
                return;
            }

            uiText.text = groupVariable.getDialogue;
        }

        public void NextDialogue(object o)
        {
            if (groupVariable.isPause)
            {
                groupVariable.isPause = false;
                NextDialogueCommand();
                groupVariable.Initialization();
            }
        }

        public void Registered()
        {
            DialogueManager.instance.Registered(this);
        }

        public void UnRegistered()
        {
            DialogueManager.instance.UnRegistered(this);
        }

        private void NextDialogueCommand()
        {
            currentIndex++;
            groupVariable.dialogueContent = groupVariable.dialogueContent + groupVariable.cacheDialogue;
            groupVariable.cacheDialogue = string.Empty;
        }
    }
}