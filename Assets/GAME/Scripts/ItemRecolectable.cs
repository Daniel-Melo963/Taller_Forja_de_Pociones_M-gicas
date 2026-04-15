using UnityEngine;

public class ItemRecolectable : MonoBehaviour
{
    private Ingrediente datos;
    private bool yaRecogido = false;

    public void Configurar(Ingrediente d)
    {
        datos = d;
        GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/" + d.iconoId);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !yaRecogido)
        {
            yaRecogido = true; // Cerramos el cerrojo inmediatamente

            Debug.Log($"Recogido: {datos.nombre}");

            if (GameManager.Instance != null)
            {
                GameManager.Instance.RegistrarRecoleccion(datos.iconoId, datos.valor);
            }

            Destroy(gameObject);
        }
    }
}
