using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerScript : MonoBehaviour
{
    private Vector2 target;
    private Animator animator;
    private Transform npcTarget = null;
    private float interactDistance = 1f;
    [HideInInspector] public bool IsWithinInteractDistance = false;

    public static PlayerScript Instance;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        animator = GetComponent<Animator>();
        target = transform.position;
    }

    void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButtonDown(0))
        {
            if (EventSystem.current.IsPointerOverGameObject()) return;

            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);

            // Réinitialiser npcTarget par défaut
            npcTarget = null;

            if (hit.collider != null)
            {
                // Si clic sur un item
                if (hit.collider.CompareTag("item"))
                {
                    //IsWithinInteractDistance = false;
                    ClickableObject pickup = hit.collider.GetComponent<ClickableObject>();
                    if (pickup != null)
                    {
                        pickup.Pickup();
                    }
                    return;
                }
                // Si clic sur un NPC
                if (hit.collider.CompareTag("NPC"))
                {
                    npcTarget = hit.collider.transform;
                    target = GetNPCStopPosition(npcTarget);
                    IsWithinInteractDistance = true;
                }
                else
                {
                    // Sinon déplacement classique vers la position cliquée
                    target = new Vector2(mousePos.x, transform.position.y);
                    IsWithinInteractDistance = false;
                }
            }
            else
            {
                // deplacement libre si rien touché
                target = new Vector2(mousePos.x, transform.position.y);
                IsWithinInteractDistance = false;
            }
            // Flip du personnage
            if (target.x > transform.position.x)
                transform.localScale = new Vector2(1, 1);
            else
                transform.localScale = new Vector2(-1, 1);

            animator.SetBool("IsMoving", true);
        }

        // GESTION DU MOUVEMENT

        if (npcTarget != null)
        {
            // Se déplacer vers le NPC
            float distToNPC = Vector2.Distance(transform.position, npcTarget.position);
            if (distToNPC > interactDistance)
            {
                transform.position = Vector2.MoveTowards(
                    transform.position,
                    target,
                    Time.deltaTime * 5.0f
                );
            }
            else
            {
                animator.SetBool("IsMoving", false);
                FlipToward(npcTarget);
                npcTarget = null;
            }
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, target, Time.deltaTime * 5.0f);
            if (Vector2.Distance(transform.position, target) <= 0.01f)
                animator.SetBool("IsMoving", false);
        }
    }

    private Vector2 GetNPCStopPosition(Transform npc)
    {
        float direction = Mathf.Sign(npc.position.x - transform.position.x);
        float stopX = npc.position.x - (direction * interactDistance);
        return new Vector2(stopX, transform.position.y);
    }

    private void FlipToward(Transform targetTransform)
    {
        if (targetTransform == null) return;

        if (targetTransform.position.x > transform.position.x)
            transform.localScale = new Vector2(1, 1); // regarde à droite
        else
            transform.localScale = new Vector2(-1, 1); // regarde à gauche
    }

}
