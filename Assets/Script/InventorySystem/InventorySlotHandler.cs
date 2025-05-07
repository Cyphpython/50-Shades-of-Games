using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventorySlotHandler : MonoBehaviour, IPointerClickHandler, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public InventoryItem linkedItem;
    private Image iconImage;
    private Transform originalParent;
    private Canvas canvas;
    private CanvasGroup canvasGroup;

    private void Start()
    {
        iconImage = GetComponentInChildren<Image>();
        canvas = GetComponentInParent<Canvas>();
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (linkedItem == null) return;
        originalParent = transform.parent;
        transform.SetParent(canvas.transform);
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (linkedItem == null) return;
        transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (linkedItem == null) return;
        transform.SetParent(originalParent);
        transform.localPosition = Vector3.zero;
        canvasGroup.blocksRaycasts = true;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (linkedItem == null) return;
        if (eventData.button == PointerEventData.InputButton.Right)
            InventoryContextMenu.Instance.Show(linkedItem, Input.mousePosition);
    }
}
