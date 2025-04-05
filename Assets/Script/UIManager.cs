using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("Map & Menu")]
    [SerializeField] private Canvas Map;
    [SerializeField] private GameObject InventoryPanel;

    private RectTransform Rt;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Map.enabled = false;
        Rt = InventoryPanel.GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        Rt.sizeDelta = new Vector2(Screen.width / 4f, 0);
    }

    public void OpenMap()
    {
        if (Map != null)
        {
            if (Map.enabled) { Map.enabled = false; } else { Map.enabled = true; }
        }
    }

    public void CloseMap()
    {
        if (Map != null)
        {
            if (Map.enabled) Map.enabled = false;
        }
    }
}
