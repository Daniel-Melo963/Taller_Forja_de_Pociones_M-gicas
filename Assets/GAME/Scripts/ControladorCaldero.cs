using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class ControladorCaldero : MonoBehaviour, IDropHandler
{
    public int idRecetaAsignada;
    private Receta datosReceta;
    private Dictionary<string, int> progresoActual = new Dictionary<string, int>();
    private bool yaTerminoEstaPocion = false;

    void Start()
    {
        datosReceta = RecipeManager.Instance.todasLasRecetas.Find(r => r.id == idRecetaAsignada);

        foreach (var obj in datosReceta.objetivos)
        {
            progresoActual[obj.ingrediente] = 0;
        }
    }

    public void OnDrop(PointerEventData eventData)
    {
        GameObject objetoSoltado = eventData.pointerDrag;

        if (objetoSoltado != null)
        {
            ItemInventario item = objetoSoltado.GetComponent<ItemInventario>();

            if (item != null)
            {
                ValidarIngrediente(item.idIngrediente, objetoSoltado);
            }
        }
    }

    void ValidarIngrediente(string id, GameObject visualItem)
    {
        ObjetivoReceta objetivo = datosReceta.objetivos.Find(o => o.ingrediente == id);

        if (objetivo != null)
        {
            if (progresoActual[id] < objetivo.cantidad)
            {
                progresoActual[id]++;
                Debug.Log($"¡Correcto! {id}: {progresoActual[id]}/{objetivo.cantidad}");

                ActualizarTextoProgreso();

                Destroy(visualItem);

                RecipeManager.Instance.MostrarRecetaActual(idRecetaAsignada - 1);

                VerificarVictoria();
            }
            else
            {
                Debug.Log("Ya pusiste suficientes de este ingrediente.");
            }
        }
        else
        {
            Debug.Log("Este ingrediente no va en esta poción. ¡Error!");
        }
    }

    void ActualizarTextoProgreso()
    {
        string mensaje = $"Cocinando: {datosReceta.nombre}\n";
        foreach (var obj in datosReceta.objetivos)
        {
            mensaje += $"{obj.ingrediente}: {progresoActual[obj.ingrediente]}/{obj.cantidad}  ";
        }
        RecipeManager.Instance.panelTextoMision.text = mensaje;
    }

    void VerificarVictoria()
    {
        if (yaTerminoEstaPocion) return;

        bool completada = true;
        foreach (var obj in datosReceta.objetivos)
        {
            if (progresoActual[obj.ingrediente] < obj.cantidad) completada = false;
        }

        if (completada)
        {
            yaTerminoEstaPocion = true;
            Debug.Log("¡POCIÓN COMPLETADA: " + datosReceta.nombre + "!");
            RecipeManager.Instance.RegistrarRecetaTerminada();
            RecipeManager.Instance.panelTextoMision.text = $"¡{datosReceta.nombre} Lista!";
        }
    }
}
