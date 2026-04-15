using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class CauldronManager : MonoBehaviour, IDropHandler
{
    public int calderaId;
    public Receta miReceta;
    public GameObject panelInfo;
    public TextMeshProUGUI txtDetalles;

    void Start()
    {
        miReceta = RecipeManager.Instance.ObtenerRecetaPorId(calderaId);
        panelInfo.SetActive(false);
        ActualizarTexto();
    }

    public void OnDrop(PointerEventData eventData)
    {
        DraggableItem item = eventData.pointerDrag.GetComponent<DraggableItem>();
        if (item != null) Validar(item.idIngrediente);
    }

    void Validar(string id)
    {
        var obj = miReceta.objetivos.Find(x => x.ingrediente == id);
        if (obj != null && obj.cantidad > 0)
        {
            Ingrediente ing = GameDataLoader.Instance.GetIngrediente(id);
            if (GameManager.Instance.UsarIngrediente(id, ing.valor))
            {
                obj.cantidad--;
                ActualizarTexto();
                //MissionManager.Instance.VerificarVictoriaFinal();
            }
        }
        else { Debug.Log("Ingrediente no compatible"); }
    }

    void ActualizarTexto()
    {
        string s = miReceta.nombre + ":\n";
        foreach (var o in miReceta.objetivos) s += $"{o.ingrediente}: {o.cantidad}\n";
        txtDetalles.text = s;
    }

    private void OnTriggerEnter2D(Collider2D other) { if (other.CompareTag("Player")) panelInfo.SetActive(true); }
    private void OnTriggerExit2D(Collider2D other) { if (other.CompareTag("Player")) panelInfo.SetActive(false); }
}
