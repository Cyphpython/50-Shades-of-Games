using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerScript : MonoBehaviour
{
    private Vector2 target;
    private Animator animator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
        target = transform.position; //Glitch Security
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButtonDown(0))
        {
            if (EventSystem.current.IsPointerOverGameObject()) return;

            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);

            if (hit.collider != null && hit.collider.CompareTag("item"))
            {
                ClickableObject pickup = hit.collider.GetComponent<ClickableObject>();
                if (pickup != null)
                {
                    pickup.Pickup();
                }
                return;
            }

            target = new Vector2(mousePos.x, transform.position.y);
            animator.SetBool("IsMoving", true);

            // Déterminer si le clic est à gauche ou à droite
            if (mousePos.x > transform.position.x)
            {
                transform.localScale = new Vector2(1, 1);
            }
            else
            {
                transform.localScale = new Vector2(-1, 1);
            }
        }
        transform.position = Vector2.MoveTowards(transform.position, target, Time.deltaTime * 5.0f);

        if (Vector2.Distance(transform.position, target) <= 0) animator.SetBool("IsMoving", false);
        
    }
}
