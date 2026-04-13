using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public GameObject prefabIngrediente;
    public Transform[] puntos;

    public void Spawnear()
    {
        int p = 0;
        foreach (var ing in GameDataLoader.Instance.todosLosIngredientes)
        {
            int cant = ing.raridad == "basico" ? 3 : (ing.raridad == "raro" ? 2 : 1);
            for (int i = 0; i < cant; i++)
            {
                if (p < puntos.Length)
                {
                    GameObject go = Instantiate(prefabIngrediente, puntos[p].position, Quaternion.identity);
                    go.GetComponent<ItemRecolectable>().Configurar(ing);
                    p++;
                }
            }
        }
    }
}
