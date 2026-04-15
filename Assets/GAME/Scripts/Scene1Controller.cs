using UnityEngine;
public class Scene1Controller : MonoBehaviour
{
    void Start()
    {
        FindObjectOfType<ItemSpawner>().Spawnear();
        UIManager.Instance.ActualizarHUD();
    }
}

