using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PuzzloCaja : MonoBehaviour
{
    public TMP_InputField inputCodigo;
    public TextMeshProUGUI textoFeedback;
    private string codigoCorrecto = "14101952";

    public void VerificarCodigo()
    {
        if (inputCodigo.text == codigoCorrecto)
        {
            PuzzleManager.Instance.puzzloCajaResuelto = true;
            textoFeedback.text = "✓ Caja abierta. Encontraste el pasaporte de Jorge.";
            textoFeedback.color = Color.green;
            inputCodigo.interactable = false;
        }
        else
        {
            textoFeedback.text = "✗ Código incorrecto. Revisá las pistas.";
            textoFeedback.color = Color.red;
        }
    }
}