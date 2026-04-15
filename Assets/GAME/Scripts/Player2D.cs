using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement2D : MonoBehaviour
{
    [Header("Ajustes")]
    public float speed = 5f;
    public float jumpForce = 3f;

    public float limiteCaida = -10f;
    private Vector3 puntoInicial;

    private Rigidbody2D rb;
    private Animator anim; 
    private Vector2 moveInput;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        puntoInicial = transform.position;
    }

    void Update()
    {
        if (transform.position.y < limiteCaida)
        {
            Reaparecer();
        }
    }

    void Reaparecer()
    {
        transform.position = puntoInicial;
        rb.linearVelocity = Vector2.zero;
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.started && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);

            
            anim.SetBool("IsJump", true);
        }
    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(moveInput.x * speed, rb.linearVelocity.y);

        
        bool running = Mathf.Abs(moveInput.x) > 0;
        anim.SetBool("IsRun", running);

        
        if (moveInput.x > 0) transform.localScale = new Vector3(1, 1, 1);
        else if (moveInput.x < 0) transform.localScale = new Vector3(-1, 1, 1);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        isGrounded = true;
       
        anim.SetBool("IsJump", false);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
       
        if (rb.linearVelocity.y < -0.1f)
        {
            anim.SetBool("IsJump", true);
        }
    }
}