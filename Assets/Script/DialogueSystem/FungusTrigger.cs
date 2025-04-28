using UnityEngine;
using Fungus;

public class FungusTrigger : MonoBehaviour
{
    public BlockReference block;
    public Flowchart fl;
    public Trigger trigger;
    public GameObject persistant;


    private void Start()
    {
        if (persistant == null)
            persistant = GameObject.Find("PERSISTOBJECTS");
        fl ??= persistant?.GetComponentInChildren<Flowchart>();
        if (fl != null && trigger != null) block.block = fl.FindBlock(trigger.TriggerName);
    }
    public void Trigger()
    {
        if (block.block != null) block.Execute();
        else Debug.LogError($"No Block assigned for trigger on {gameObject.name}");
    }

}
