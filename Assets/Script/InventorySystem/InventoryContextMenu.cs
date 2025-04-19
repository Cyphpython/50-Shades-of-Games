using UnityEngine;
using UnityEngine.UI;
using Fungus;

public class InventoryContextMenu : MonoBehaviour
{
    public static InventoryContextMenu Instance;

    public GameObject panel;
    public Button useButton;
    public Button examineButton;

    [SerializeField] private Flowchart fl;
    private InventoryItem currentItem;

    private void Awake()
    {
        Instance = this;
        panel.SetActive(false);
        FlowchartManager.SetFlowchart(fl);
    }

    public void Show(InventoryItem item, Vector2 screenPos)
    {
        if (item == null) return;

        currentItem = item;
        panel.SetActive(true);

        //Calculate menu position without layout overflowing
        RectTransform rect = panel.GetComponent<RectTransform>();
        float width = rect.rect.width;
        float height = rect.rect.height;

        Vector2 adjustedPos = screenPos;
        if (screenPos.x + width > Screen.width) adjustedPos.x -= width;
        if (screenPos.y - height < 0) adjustedPos.y += height;

        panel.transform.position = adjustedPos;

        useButton.interactable = item.IsUsable;

        useButton.onClick.RemoveAllListeners();
        examineButton.onClick.RemoveAllListeners();

        useButton.onClick.AddListener(() =>
        {
            panel.SetActive(false);
            item?.OnUse();
            ExamineUI.Instance?.Hide();
        });

        examineButton.onClick.AddListener(() =>
        {
            panel.SetActive(false);
            ExamineUI.Instance?.Show(item.itemIcon, item.itemDescription);
        });
    }
    public void Hide()
        { panel.SetActive(false); }
}
