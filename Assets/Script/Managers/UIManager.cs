using Fungus;
using UnityEngine;


public class UIManager : MonoBehaviour
{

    public static UIManager Instance;

    [Header("Map & Menu")]
    [SerializeField] private Canvas Map;
    [SerializeField] private GameObject InventoryPanel;
    [SerializeField] private string SaveBlock;

    public Flowchart _FL;
    public BlockReference Cascade;

    private RectTransform Rt;

    private void Awake() 
    {
        if (Instance == null) Instance = this; else Destroy(gameObject);
    }

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

    public void SaveButton()
    {
        if (SaveBlock  != null && _FL != null)
        {
            _FL.ExecuteBlock(SaveBlock);
        }
    }

    public void GotoCascade()
    {
        if (Cascade.block != null) { Cascade.Execute(); }
    }
}
