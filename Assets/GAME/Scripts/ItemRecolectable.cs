using UnityEngine;

public class ItemRecolectable : MonoBehaviour
{
    private Ingrediente datos;
    private bool yaRecogido = false;

    public void Configurar(Ingrediente d)
    {
        datos = d;
        if (datos != null)
        {
            GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/" + d.iconoId);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.CompareTag("Player") && !yaRecogido)
        {
            yaRecogido = true;

            
            if (datos != null)
            {
                Debug.Log($"Recogido: {datos.nombre}");

                if (GameManager.Instance != null)
                {
                    GameManager.Instance.RegistrarRecoleccion(datos.iconoId, datos.valor);
                }
            }
            else
            {
                Debug.LogWarning("El objeto no tiene 'datos' asignados, pero se destruirá igual.");
            }

            
            Destroy(gameObject);
        }
    }
}