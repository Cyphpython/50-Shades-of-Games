using UnityEngine;

public class SceneDecorSwitch : MonoBehaviour
{
    [SerializeField] private Canvas DecorJour;
    [SerializeField] private Canvas DecorNuit;
    [SerializeField] private string ControlVarJour;
    [SerializeField] private string ControlVarNuit;
    [SerializeField] private Fungus.BooleanVariable FungusControlVarNuit;
    [SerializeField] private Fungus.BooleanVariable FungusControlVarJour;

    private void Start()
    {
        FungusControlVarJour = FlowchartManager.GetBoolVar(ControlVarJour);
        FungusControlVarNuit = FlowchartManager.GetBoolVar(ControlVarNuit);
    }

    private void Update()
    {
        if (FungusControlVarJour != null && FungusControlVarJour.Value == true)
        {
            DecorJour.enabled = true;
        }
        else
        {
            DecorJour.enabled = false;
        }
        if (FungusControlVarNuit != null && FungusControlVarNuit.Value == true)
        {
            DecorNuit.enabled = true;
        }
        else
        {
            DecorNuit.enabled = false;
        }
    }

}
