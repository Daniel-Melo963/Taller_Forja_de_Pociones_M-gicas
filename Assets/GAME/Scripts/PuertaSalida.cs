using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PuertaSalida : MonoBehaviour
{
    public TextMeshProUGUI textoEstado;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (MissionManager.Instance.YaTieneLosDoce())
            {
                textoEstado.text = "¡GANASTE! Entrando al laboratorio...";
                Invoke("CambiarEscena", 6f);
            }
            else
            {
                textoEstado.text = "Aún te faltan ingredientes para avanzar.";
            }
        }
    }

    void CambiarEscena()
    {
        SceneManager.LoadScene("SceneRecetas");
    }
}
