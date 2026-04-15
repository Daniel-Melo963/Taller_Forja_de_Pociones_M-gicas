using UnityEngine;
using UnityEngine.SceneManagement;

public class MissionManager : MonoBehaviour
{
    public static MissionManager Instance;
    private void Awake() { if (Instance == null) { Instance = this; DontDestroyOnLoad(gameObject); } }

    // Función simplificada: solo suma y nos dice si ya completamos los 12
    public bool YaTieneLosDoce()
    {
        int total = 0;
        foreach (var item in GameManager.Instance.inventario)
        {
            total += item.Value;
        }
        return total >= 12;
    }
}
