using UnityEngine;
public class Scene1Controller : MonoBehaviour
{
    void Start()
    {
        Object.FindFirstObjectByType<ItemSpawner>().Spawnear();
        UIManager.Instance.ActualizarHUD();
    }
}

