using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GameCore.Dialogue;
using GameCore.UI;

public class DialogueDemo : MonoBehaviour
{
    public List<string> dialogues = new List<string>();

    public Text demo_Text;
    public UIButton demo_Button;

    private Dialogue dialogue;

    private void Start()
    {
        dialogue = new Dialogue();

        dialogue.Initialization().SetDialogue(demo_Text).ParseCommands(dialogues).Registered();

        //UIEventListener.Get(demo_Button.gameObject).OnClickDown += dialogue.NextDialogue;
        //demo_Button.OnClick = new TriggerButton(dialogue.NextDialogue);
    }

    private void OnDisable()
    {
        if (dialogue != null)
        {
            dialogue.UnRegistered();
        }
    }
}
