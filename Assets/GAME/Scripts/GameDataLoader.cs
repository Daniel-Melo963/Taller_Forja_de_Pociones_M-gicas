using UnityEngine;
using System.Collections.Generic;
using System.IO;

public class GameDataLoader : MonoBehaviour
{
    public static GameDataLoader Instance;
    public List<Ingrediente> todosLosIngredientes;

    private void Awake()
    {
        if (Instance == null) { Instance = this; DontDestroyOnLoad(gameObject); CargarDatos(); }
        else Destroy(gameObject);
    }

    void CargarDatos()
    {
        string path = Path.Combine(Application.streamingAssetsPath, "Ingredientes.json");
        string jsonText = File.ReadAllText(path);
        IngredientesWrapper wrapper = JsonUtility.FromJson<IngredientesWrapper>(jsonText);
        todosLosIngredientes = wrapper.ingredientes;
    }

    public Ingrediente GetIngrediente(string id) => todosLosIngredientes.Find(x => x.iconoId == id);
}

[System.Serializable]
public class Ingrediente
{
    public string nombre; public int valor; public string iconoId; public string raridad;
}
[System.Serializable] public class IngredientesWrapper { public List<Ingrediente> ingredientes; }
