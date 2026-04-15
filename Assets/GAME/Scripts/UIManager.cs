using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    public TextMeshProUGUI txtPuntos, txtHongo, txtOjo, txtRaiz, txtSalamandra, txtPolvo, txtLagrima;

    private void Awake() { Instance = this; }

    public void ActualizarHUD()
    {
        txtPuntos.text = "" + GameManager.Instance.puntosTotales;
        txtHongo.text = "" + GameManager.Instance.GetCantidad("hongo") + "/3";
        txtOjo.text = "" + GameManager.Instance.GetCantidad("ojo") + "/3";
        txtRaiz.text = "" + GameManager.Instance.GetCantidad("raiz") + "/2";
        txtSalamandra.text = "" + GameManager.Instance.GetCantidad("salamandra") + "/2";
        txtPolvo.text = "" + GameManager.Instance.GetCantidad("polvo") + "/1";
        txtLagrima.text = "" + GameManager.Instance.GetCantidad("lagrima") + "/1";
    }
}
