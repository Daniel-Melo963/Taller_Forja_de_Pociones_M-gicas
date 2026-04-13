using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    public TextMeshProUGUI txtPuntos, txtHongo, txtOjo, txtRaiz, txtSalamandra, txtPolvo, txtLagrima;

    private void Awake() { Instance = this; }

    public void ActualizarHUD()
    {
        txtPuntos.text = "Puntos: " + GameManager.Instance.puntosTotales;
        txtHongo.text = "Hongo: " + GameManager.Instance.GetCantidad("hongo") + "/3";
        txtOjo.text = "Ojo: " + GameManager.Instance.GetCantidad("ojo") + "/3";
        txtRaiz.text = "Raiz: " + GameManager.Instance.GetCantidad("raiz") + "/2";
        txtSalamandra.text = "Salamandra: " + GameManager.Instance.GetCantidad("salamandra") + "/2";
        txtPolvo.text = "Polvo: " + GameManager.Instance.GetCantidad("polvo") + "/1";
        txtLagrima.text = "Lagrima: " + GameManager.Instance.GetCantidad("lagrima") + "/1";
    }
}
