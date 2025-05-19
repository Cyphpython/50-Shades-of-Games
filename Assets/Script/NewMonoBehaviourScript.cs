using UnityEngine;

public class PNJHandler : MonoBehaviour
{
    public string VarToGet;
    public GameObject pnj;

    private bool s;
    void Update()
    {
        s = FlowchartManager.GetBoolVar(VarToGet);
        if (s == true)
        {
            transform.gameObject.SetActive(false);
            pnj.SetActive(true);
        }
    }
}
