using UnityEngine;
using UnityEngine.SceneManagement;

public class MissionManager : MonoBehaviour
{
    public static MissionManager Instance;
    private void Awake() { if (Instance == null) { Instance = this; DontDestroyOnLoad(gameObject); } }

    public void VerificarMision1()
    {
        int total = 0;
        foreach (var item in GameManager.Instance.inventario) total += item.Value;
        if (total >= 12) SceneManager.LoadScene("Escena2");
    }

    public void VerificarVictoriaFinal()
    {
        if (GameManager.Instance.puntosTotales <= 0) SceneManager.LoadScene("PantallaGanaste");
    }
}
