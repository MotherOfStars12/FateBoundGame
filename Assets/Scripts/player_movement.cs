using UnityEngine;

public class player_movement : MonoBehaviour
{

    [SerializeField] float runSpeed = 5f; 
    [SerializeField] float deadZone = 0.01f; 


    //cache
    private Rigidbody2D rb;
    private Vector2 movementInput;
    private Animator animator;

    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    
    void Update()
    {
        movementInput.x = Input.GetAxisRaw("Horizontal");
        movementInput.y = Input.GetAxisRaw("Vertical");

        movementInput = movementInput.normalized;

        float speed = movementInput.magnitude;

        //controlar animaciones
        animator.SetFloat("moveX", movementInput.x);
        animator.SetFloat("moveY", movementInput.y);
        animator.SetFloat("speed", movementInput.magnitude);

        if (speed > deadZone)
        {
            Vector2 last = DirectionMajorAxis(movementInput);
            animator.SetFloat("lastX", last.x);   
            animator.SetFloat("lastY", last.y);   
        }


    }

    private void FixedUpdate()
    {
        rb.linearVelocity = movementInput * runSpeed;
    }

    Vector2 DirectionMajorAxis(Vector2 v)
    {
        if (Mathf.Abs(v.x) > Mathf.Abs(v.y))
            return new Vector2(Mathf.Sign(v.x), 0f); 
        else
            return new Vector2(0f, Mathf.Sign(v.y)); 
    }
}
