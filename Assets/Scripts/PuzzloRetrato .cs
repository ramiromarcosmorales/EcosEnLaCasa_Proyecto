using UnityEngine;
using TMPro;

public class PuzzloRetrato : MonoBehaviour
{
    public TMP_InputField inputCodigo;
    public TextMeshProUGUI textoFeedback;
    // Número oculto al dorso del retrato: 1979
    private string codigoCorrecto = "1979";

    public void VerificarCodigo()
    {
        if (inputCodigo.text.Trim() == codigoCorrecto)
        {
            PuzzleManager.Instance.puzzloRetratoResuelto = true;
            textoFeedback.text = "✓ Correcto. Al dorso del retrato: 1979. El año que desaparecieron.";
            textoFeedback.color = Color.green;
            inputCodigo.interactable = false;
        }
        else
        {
            textoFeedback.text = "✗ Incorrecto. Observá bien el dorso del retrato.";
            textoFeedback.color = Color.red;
        }
    }
}