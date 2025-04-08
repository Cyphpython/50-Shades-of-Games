using UnityEngine;

[CreateAssetMenu(fileName = "SO_Dialogue", menuName = "Dialogue/DialogueText")]
public class SO_Dialogue : ScriptableObject
{
    public string speakerName;

    [TextArea(5, 10)]
    public string[] paragraphs; //Actual dialogue
}
