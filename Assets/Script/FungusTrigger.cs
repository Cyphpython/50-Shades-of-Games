using UnityEngine;
using Fungus;

public class FungusTrigger : MonoBehaviour
{
    public BlockReference block;

    public void TriggerDialogue()
    {
        block.Execute();
    }
}
