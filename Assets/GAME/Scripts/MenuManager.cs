using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [Header("Paneles de la UI")]
    public GameObject panelPrincipal;
    public GameObject panelInstrucciones;
    public GameObject panelGanaste;
    public GameObject panelPerdiste;

    void Start()
    {
        panelPrincipal.SetActive(true);
        panelInstrucciones.SetActive(false);
        panelGanaste.SetActive(false);
        panelPerdiste.SetActive(false);
    }

    public void Jugar()
    {
        SceneManager.LoadScene("SceneIngredientes");
    }
    
    public void AbrirInstrucciones()
    {
        panelPrincipal.SetActive(false);
        panelInstrucciones.SetActive(true);
    }

    public void VolverAlMenu()
    {
        panelInstrucciones.SetActive(false);
        panelGanaste.SetActive(false);
        panelPerdiste.SetActive(false);
        panelPrincipal.SetActive(true);
    }

    public void Salir()
    {
        Debug.Log("Saliendo del alquimista...");
        Application.Quit();
    }
}
