using GameCore;
using UnityEngine;
using System.Collections.Generic;

namespace GameCore.Dialogue
{
    public class DialogueManager : MonoSingleton<DialogueManager>
    {
        public List<Dialogue> dialogues = new List<Dialogue>();

        public void Registered(Dialogue dialogue)
        {
            if (dialogues.Contains(dialogue))
            {
                return;
            }

            dialogues.Add(dialogue);
        }

        public void UnRegistered(Dialogue dialogue)
        {
            if (dialogues.Contains(dialogue) == false)
            {
                return;
            }

            dialogues.Remove(dialogue);
        }

        private void Update()
        {
            for (int i = 0 , Count = dialogues.Count; i < Count; i ++)
            {
                dialogues[i].Update(Time.deltaTime);
            }
        }
    }
}