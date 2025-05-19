using Unity.VisualScripting;
using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public string VarToGet;
    public GameObject pnj;
    void Update()
    {
        Fungus.BooleanVariable s = FlowchartManager.GetBoolVar(VarToGet);
        if (s.Value == true)
        {
            transform.gameObject.SetActive(false);
            pnj.SetActive(true);
        }
    }
}
