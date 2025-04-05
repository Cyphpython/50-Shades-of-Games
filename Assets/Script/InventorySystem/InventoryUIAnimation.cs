using UnityEngine;
using System.Collections;

public class InventoryUIAnimation : MonoBehaviour
{
    public float animationDuration = 0.3f;

    private RectTransform rt;
    private CanvasGroup CG;
    private bool isVisible = false;
    private Vector2 hiddenPosition;
    private Vector2 visiblePosition;

    void Awake()
    {
        rt = GetComponent<RectTransform>();
        CG = rt.GetComponent<CanvasGroup>();
        visiblePosition = rt.anchoredPosition;
        hiddenPosition = new Vector2(Screen.width, rt.anchoredPosition.y);

        rt.anchoredPosition = hiddenPosition;
        CG.alpha = 0f;
        CG.interactable = false;
        CG.blocksRaycasts = false;
    }

    public void Toggle()
    {
        if (isVisible)
        {
            Hide();
        }
        else
        {
            Show();
        }
    }

    public void Show()
    {
        isVisible = true;
        StopAllCoroutines();
        StartCoroutine(AnimateIn());
    }

    public void Hide()
    {
        isVisible = false;
        StopAllCoroutines();
        StartCoroutine(AnimateOut());
    }

    IEnumerator AnimateIn()
    {
        float t = 0;
        Vector2 start = rt.anchoredPosition;
        while (t < animationDuration)
        {
            t += Time.deltaTime;
            float progress = t / animationDuration;
            rt.anchoredPosition = Vector2.Lerp(start, visiblePosition, progress);
            CG.alpha = 0f + progress;
            yield return null;
        }
        rt.anchoredPosition = visiblePosition;
        CG.alpha = 1f;
        CG.interactable = true;
        CG.blocksRaycasts = true;
    }

    IEnumerator AnimateOut()
    {
        float t = 0;
        Vector2 start = rt.anchoredPosition;
        while (t < animationDuration)
        {
            t += Time.deltaTime;
            float progress = t / animationDuration;
            rt.anchoredPosition = Vector2.Lerp(start, hiddenPosition, progress);
            CG.alpha = 1f - progress;
            yield return null;
        }
        rt.anchoredPosition = hiddenPosition;
        CG.alpha = 0f;
        CG.interactable = false;
        CG.blocksRaycasts = false;
    }
}
