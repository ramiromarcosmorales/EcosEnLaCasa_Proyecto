using UnityEngine;
using TMPro;

public class PuzzloRecorte : MonoBehaviour
{
    public TextMeshProUGUI textoFeedback;
    private string[] ordenJugador = new string[3];
    private int posicionActual = 0;

    public void SeleccionarDocumento1978()
    {
        if (posicionActual >= 3) return;
        ordenJugador[posicionActual] = "1978";
        posicionActual++;
        textoFeedback.text = "Seleccionado " + posicionActual + "/3";
    }

    public void SeleccionarDocumento1979marzo()
    {
        if (posicionActual >= 3) return;
        ordenJugador[posicionActual] = "1979marzo";
        posicionActual++;
        textoFeedback.text = "Seleccionado " + posicionActual + "/3";
    }

    public void SeleccionarDocumento1979noviembre()
    {
        if (posicionActual >= 3) return;
        ordenJugador[posicionActual] = "1979noviembre";
        posicionActual++;
        textoFeedback.text = "Seleccionado " + posicionActual + "/3";
    }

    public void VerificarOrden()
    {
        if (posicionActual < 3)
        {
            textoFeedback.text = "✗ Seleccioná los 3 documentos primero.";
            textoFeedback.color = Color.red;
            return;
        }

        string[] ordenCorrecto = { "1978", "1979marzo", "1979noviembre" };
        for (int i = 0; i < ordenCorrecto.Length; i++)
        {
            if (ordenJugador[i] != ordenCorrecto[i])
            {
                textoFeedback.text = "✗ Orden incorrecto. Reiniciá y volvé a intentar.";
                textoFeedback.color = Color.red;
                posicionActual = 0;
                ordenJugador = new string[3];
                return;
            }
        }
        PuzzleManager.Instance.puzzloRecorteResuelto = true;
        textoFeedback.text = "✓ Correcto. La historia oficial no cierra.";
        textoFeedback.color = Color.green;
    }
}