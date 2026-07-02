using UnityEngine;
using TMPro;

public class PuzzloLista : MonoBehaviour
{
    public TMP_InputField inputNombre;
    public TextMeshProUGUI textoFeedback;
    // La respuesta es Tito, el único con TRASLADO confirmado
    private string respuestaCorrecta = "Tito";

    public void VerificarRespuesta()
    {
        if (inputNombre.text.Trim() == respuestaCorrecta)
        {
            PuzzleManager.Instance.puzzloListaResuelto = true;
            textoFeedback.text = "✓ Correcto. Tito fue trasladado. El contacto de Munro está comprometido.";
            textoFeedback.color = Color.green;
            inputNombre.interactable = false;
        }
        else
        {
            textoFeedback.text = "✗ Incorrecto. ¿Quién figura como TRASLADO en la lista?";
            textoFeedback.color = Color.red;
        }
    }
}