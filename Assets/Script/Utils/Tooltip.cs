using UnityEngine;
using TMPro;
using UnityEngine.UI;

[ExecuteInEditMode()]
public class Tooltip : MonoBehaviour
{
    public TextMeshProUGUI headerField;
    public TextMeshProUGUI contentField;
    public LayoutElement layoutElement;
    public int characterWrapLimit;
    public RectTransform RT;

    private void Awake()
    {
        RT = GetComponent<RectTransform>();
    }

    public void SetText(string content, string header = "")
    {
        if (string.IsNullOrEmpty(header)) headerField.gameObject.SetActive(false);
        else headerField.gameObject.SetActive(true); headerField.text = header;
        contentField.text = content;
        int headerLength = headerField.text.Length;
        int contentLength = contentField.text.Length;
        layoutElement.enabled = headerField.preferredWidth > layoutElement.preferredWidth || contentField.preferredWidth > layoutElement.preferredWidth;
    }

    private void Update()
    {
        Vector2 position = Input.mousePosition;
        float pivotX = position.x/Screen.width;
        float pivotY = position.y/Screen.height;
        if (RT != null) RT.pivot = new Vector2(pivotX, pivotY);
        transform.position = position;
    }
}
