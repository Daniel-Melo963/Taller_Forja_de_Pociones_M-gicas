using UnityEngine;
using UnityEngine.UI;

public class InventarioCaldero : MonoBehaviour
{
    public GameObject prefabItem;
    public Transform panelContenedor;

    void Start()
    {
        GenerarInventario();
    }

    public void GenerarInventario()
    {
        foreach (Transform hijo in panelContenedor) Destroy(hijo.gameObject);
        foreach (var item in GameManager.Instance.inventario)
        {
            
            for (int i = 0; i < item.Value; i++)
            {
                GameObject nuevoItem = Instantiate(prefabItem, panelContenedor);
                Sprite imagenSpreite = Resources.Load<Sprite>("Sprites/" + item.Key);
                nuevoItem.GetComponent<Image>().sprite = imagenSpreite;
                nuevoItem.GetComponent<ItemInventario>().idIngrediente = item.Key;
            }
        }
    }
}
