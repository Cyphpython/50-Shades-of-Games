using Fungus;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerScript : MonoBehaviour
{
    private Transform npcTarget = null;

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

            // Réinitialiser npcTarget par défaut
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
            }
        }
    }
}