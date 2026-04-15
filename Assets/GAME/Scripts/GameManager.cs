using UnityEngine;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public int puntosTotales = 0;
    public Dictionary<string, int> inventario = new Dictionary<string, int>();

    private void Awake()
    {
        if (Instance == null) { Instance = this; DontDestroyOnLoad(gameObject); }
        else Destroy(gameObject);
    }

    public void RegistrarRecoleccion(string id, int valor)
    {
        puntosTotales += valor;
        if (!inventario.ContainsKey(id)) inventario.Add(id, 0);
        inventario[id]++;
        UIManager.Instance.ActualizarHUD();
        //MissionManager.Instance.VerificarMision1();
    }

    public bool UsarIngrediente(string id, int valor)
    {
        if (inventario.ContainsKey(id) && inventario[id] > 0)
        {
            inventario[id]--;
            puntosTotales -= valor;
            UIManager.Instance.ActualizarHUD();
            return true;
        }
        return false;
    }

    public int GetCantidad(string id) => inventario.ContainsKey(id) ? inventario[id] : 0;
}

