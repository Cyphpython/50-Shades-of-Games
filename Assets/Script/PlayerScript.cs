using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private Vector2 target;
    private Animator animator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButtonDown(0))
        {
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
