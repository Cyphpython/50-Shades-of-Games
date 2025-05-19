using Fungus;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerScript : MonoBehaviour
{
    private Transform npcTarget = null;
    [SerializeField] private GameObject _craftingUI;

    public static PlayerScript Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);

            // R�initialiser npcTarget par d�faut
            npcTarget = null;

            if (hit.collider != null)
            {
                // Si clic sur un item
                if (hit.collider.CompareTag("item"))
                {
                    ClickableObject pickup = hit.collider.GetComponent<ClickableObject>();
                    if (pickup != null)
                    {
                        pickup.Pickup();
                    }
                    return;
                }
                else if (hit.collider.CompareTag("NPC") || hit.collider.CompareTag("Waypoint"))
                {
                    npcTarget = hit.collider.transform;
                    FungusTrigger ft = npcTarget.GetComponent<FungusTrigger>();
                    ft?.Trigger();
                    npcTarget = null;
                }
                else if (hit.collider.CompareTag("Crafter"))
                {
                    _craftingUI.SetActive(true);
                }
                else if (hit.collider.CompareTag("Arrow"))
                {
                    UIManager.Instance?.OpenMap();
                }
            }
        }
    }
}