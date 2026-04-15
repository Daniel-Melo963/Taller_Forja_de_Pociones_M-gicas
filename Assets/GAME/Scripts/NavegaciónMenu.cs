using UnityEngine;
using UnityEngine.SceneManagement; // Necesario para cambiar de escena

public class NavegacionMenu : MonoBehaviour
{
    public void IrAlMenuPrincipal()
    {
        Time.timeScale = 1f;

        SceneManager.LoadScene("MenuPrincipal");
    }
}
