using UnityEngine;
using System.Collections.Generic;
using System.IO;

public class RecipeManager : MonoBehaviour
{
    public static RecipeManager Instance;
    public List<Receta> todasLasRecetas;

    private void Awake()
    {
        if (Instance == null) { Instance = this; DontDestroyOnLoad(gameObject); CargarRecetas(); }
        else Destroy(gameObject);
    }

    void CargarRecetas()
    {
        string path = Path.Combine(Application.streamingAssetsPath, "Recetas.json");
        string jsonText = File.ReadAllText(path);
        RecetasWrapper wrapper = JsonUtility.FromJson<RecetasWrapper>(jsonText);
        todasLasRecetas = wrapper.recetas;
    }

    public Receta ObtenerRecetaPorId(int id) => todasLasRecetas.Find(r => r.id == id);
}

[System.Serializable] public class ObjetivoReceta { public string ingrediente; public int cantidad; }
[System.Serializable] public class Receta { public int id; public string nombre; public List<ObjetivoReceta> objetivos; }
[System.Serializable] public class RecetasWrapper { public List<Receta> recetas; }

