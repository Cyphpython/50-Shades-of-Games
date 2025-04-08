using UnityEngine;
using TMPro;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine.UI;
using System.Collections;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] private Image NPCImage;
    [SerializeField] private TextMeshProUGUI NPCNameText;
    [SerializeField] private TextMeshProUGUI NPCDialogueText;
    [SerializeField] private float typeSpeed;

    private Queue<string> paragraphs = new Queue<string>();

    private Coroutine StartTypingCoroutine;

    private const string HTML_ALPHA = "<color=#00000000>";
    private const float MAX_TYPE_TIME = 0.1f;

    private bool convoEnded;
    private bool isTyping;
    private string p;

    public void DisplayNextParagraph(SO_Dialogue dialogueText)
    {
        //if empty
        if (paragraphs.Count == 0)
        {
            if (!convoEnded)
            {
                //Start the convo
                StartConversation(dialogueText);
            }

            else if (convoEnded && !isTyping)
            {
                //end the convo 
                EndConversation();
                return;
            }
        }
        //if not empty
        if (!isTyping)
        {
            p = paragraphs.Dequeue();
            StartTypingCoroutine = StartCoroutine(TypeDialogueText(p));
        }
        else
        {
            FinishInteractEarly();
        }
        
        if (paragraphs.Count == 0) convoEnded = true;
    }

    private void StartConversation(SO_Dialogue dialogueText)
    {
        //activate gameObject
        if (!NPCImage.gameObject.activeSelf) NPCImage.gameObject.SetActive(true);
        //update the speaker name
        NPCNameText.text = dialogueText.speakerName;
        //add text to the queue
        for (int i = 0; i < dialogueText.paragraphs.Length; i++)
        {
            paragraphs.Enqueue(dialogueText.paragraphs[i]);
        }
    }

    private void EndConversation()
    {
        //clear the queue
        convoEnded = false;
        if (NPCImage.gameObject.activeSelf) NPCImage.gameObject.SetActive(false);
    }

    private IEnumerator TypeDialogueText(string p)
    {
        isTyping = true;

        NPCDialogueText.text = "";
        string originalText = p;
        string displayedText = "";
        int alpahIndex = 0;
        foreach (char c in p.ToCharArray())
        {
            alpahIndex++;
            NPCDialogueText.text = originalText;
            displayedText = NPCDialogueText.text.Insert(alpahIndex, HTML_ALPHA);
            NPCDialogueText.text = displayedText;
            yield return new WaitForSeconds(MAX_TYPE_TIME / typeSpeed);
        }
        isTyping = false;
    }

    private void FinishInteractEarly()
    {
        StopCoroutine(StartTypingCoroutine);
        NPCDialogueText.text = p;
        isTyping = false;
    }
}
