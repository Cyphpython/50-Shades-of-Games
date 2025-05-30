using UnityEngine;
using Fungus;

public class FungusTrigger : MonoBehaviour
{
    [Header("Fungus")]
    public BlockReference block;
    public Flowchart fl;
    public Trigger trigger;
    public GameObject DarkBG;

    public GameObject persistant;

    private bool _isPlaying = false;

    private void Start()
    {
        if (persistant == null)
            persistant = GameObject.Find("PERSISTOBJECTS");
        DarkBG = GameObject.Find("PNJTalkBGCanvas");
        DarkBG?.SetActive(false);
        fl ??= persistant?.GetComponentInChildren<Flowchart>();
        if (fl != null && trigger != null) block.block = fl.FindBlock(trigger.TriggerName);
    }
    public void Trigger()
    {
        if (block.block != null) { block.Execute(); DarkBG?.SetActive(true); _isPlaying = true; }
        else { Debug.LogError($"No Block assigned for trigger on {gameObject.name}"); }
    }

    private void Update()
    {
        if (_isPlaying)
        {
            if(!fl.GetExecutingBlocks().Contains(block.block))
            {
                _isPlaying = false;
                OnBlockFinished();
            }
        }
    }

    private void OnBlockFinished()
    {
        DarkBG?.SetActive(false);
        PlayerScript.Instance.sr.enabled = true;
    }

}
