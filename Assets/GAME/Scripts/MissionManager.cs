using UnityEngine;
using UnityEngine.SceneManagement;

public class MissionManager : MonoBehaviour
{
    public static MissionManager Instance;
    private void Awake() { if (Instance == null) { Instance = this; DontDestroyOnLoad(gameObject); } }

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
