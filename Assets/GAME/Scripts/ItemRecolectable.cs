using UnityEngine;

public class ItemRecolectable : MonoBehaviour
{
    private Ingrediente datos;
    public void Configurar(Ingrediente d)
    {
        datos = d;
        GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/" + d.iconoId);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log($"Nombre: {datos.nombre} | Raridad: {datos.raridad} | Valor: {datos.valor}");
            GameManager.Instance.RegistrarRecoleccion(datos.iconoId, datos.valor);
            Destroy(gameObject);
        }
    }
}
