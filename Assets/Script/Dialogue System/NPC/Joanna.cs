using UnityEngine;

public class Joanna : NCP_Base, ITalkable
{
    [SerializeField] private SO_Dialogue _dialogueText;
    [SerializeField] private DialogueManager _dialogueManager;
    public override void Interact()
    {
        Talk(_dialogueText);
    }

    public void Talk(SO_Dialogue dialogueText)
    {
        //start convo
        _dialogueManager.DisplayNextParagraph(dialogueText);
    }
}
