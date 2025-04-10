using UnityEngine;

public class NPCFeedback : MonoBehaviour
{
    [SerializeField] private SpriteRenderer Arrowfeedback;

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(PlayerScript.Instance.transform.position, transform.position) > 1.1f) Arrowfeedback.enabled = false;
        if (Vector2.Distance(PlayerScript.Instance.transform.position, transform.position) <= 1.1f) Arrowfeedback.enabled = true;
    }
}
