using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class TooltipTrigger : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField]private InventoryItem item;
    [SerializeField]private InventorySlotHandler slotHandler;
    private Coroutine hoveringTween;

    public void OnPointerEnter(PointerEventData eventData)
    {
        slotHandler = GetComponent<InventorySlotHandler>();
        if (slotHandler != null) { item = slotHandler.linkedItem; } else { Debug.LogError("no slothandler"); }
        #region ErrorHandling
        if (item == null) { Debug.LogError("no item"); return; }
        else if (string.IsNullOrEmpty(item.itemDescription)) { Debug.LogError("No description"); return; }
        else if (string.IsNullOrEmpty(item.itemName)) { Debug.LogError("No name"); return; }
        #endregion
        hoveringTween = StartCoroutine(HoveringTweening());
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (hoveringTween != null)
        {
            StopCoroutine(hoveringTween);
        }
        TooltipSystem.Hide();
    }

    private IEnumerator HoveringTweening()
    {
        yield return new WaitForSeconds(0.5f);
        TooltipSystem.Show(item.itemDescription, item.itemName);
    }
}
