using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RecipeManager : MonoBehaviour
{
    public static RecipeManager Instance;
    public List<Receta> todasLasRecetas;
    public TextMeshProUGUI panelTextoMision;
    private int recetasCompletadas = 0;
    public GameObject panelGanaste;

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

    public void MostrarRecetaActual(int indice)
    {
        Receta r = todasLasRecetas[indice];
        string listaObjetivos = $"Misión: {r.nombre}\n";

        foreach (var obj in r.objetivos)
        {
            listaObjetivos += $"- {obj.ingrediente}: {obj.cantidad}\n";
        }

        panelTextoMision.text = listaObjetivos;
    }

    public void RegistrarRecetaTerminada()
    {
        recetasCompletadas++;

        if (recetasCompletadas >= todasLasRecetas.Count)
        {
            panelGanaste.SetActive(true);
            Time.timeScale = 0f;
            Cursor.visible = true;
        }
    }

    void IrAPantallaGanaste()
    {
        SceneManager.LoadScene("PantallaGanaste");
    }

    public Receta ObtenerRecetaPorId(int id) => todasLasRecetas.Find(r => r.id == id);
}

[System.Serializable] public class ObjetivoReceta { public string ingrediente; public int cantidad; }
[System.Serializable] public class Receta { public int id; public string nombre; public List<ObjetivoReceta> objetivos; }
[System.Serializable] public class RecetasWrapper { public List<Receta> recetas; }
