using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ExamineUI : MonoBehaviour
{
    public static ExamineUI Instance;

    public GameObject panel;
    public Image itemImage;
    public TextMeshProUGUI descriptionText;

    private void Awake()
    {
        Instance = this;
        panel.SetActive(false);
    }

    public void Show(Sprite image, string description)
    {
        panel.SetActive(true);
        itemImage.sprite = image;
        itemImage.enabled = image != null;
        descriptionText.text = description;
    }

    public void Hide()
        { panel.SetActive(false); }
}
