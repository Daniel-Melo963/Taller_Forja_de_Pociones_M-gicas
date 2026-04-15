using UnityEngine;

public class PlayerMovement2D : MonoBehaviour
{
    public float speed = 5f;

    private Rigidbody2D rb;
    private Vector2 movement;

    void Start()
    {
        // Obtenemos el componente al iniciar
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // 1. Capturar el Input (WASD o Flechas)
        // Usamos GetAxisRaw para una respuesta instantánea y precisa
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        // 2. Opcional: Girar el personaje hacia donde se mueve
        if (movement.x > 0) transform.localScale = new Vector3(1, 1, 1);
        else if (movement.x < 0) transform.localScale = new Vector3(-1, 1, 1);
    }

    void FixedUpdate()
    {
        // 3. Aplicar el movimiento físico
        // .normalized evita que el jugador corra más rápido al moverse en diagonal
        rb.MovePosition(rb.position + movement.normalized * speed * Time.fixedDeltaTime);
    }
}