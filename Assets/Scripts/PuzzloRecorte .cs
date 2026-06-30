using UnityEngine;
using TMPro;

public class PuzzloRecorte : MonoBehaviour
{
    public TextMeshProUGUI textoFeedback;
    // Documentos en orden cronológico correcto:
    // 1. Pasaporte (Feb 1978)
    // 2. Carta Giménez (Marzo 1979)
    // 3. Recorte La Razón (Noviembre 1979)
    private string[] ordenCorrecto = { "1978", "1979marzo", "1979noviembre" };
    private string[] ordenJugador = new string[3];

    public void SeleccionarDocumento(int posicion, string fecha)
    {
        ordenJugador[posicion] = fecha;
    }

    public void VerificarOrden()
    {
        for (int i = 0; i < ordenCorrecto.Length; i++)
        {
            if (ordenJugador[i] != ordenCorrecto[i])
            {
                textoFeedback.text = "✗ Orden incorrecto. Revisá las fechas de los documentos.";
                textoFeedback.color = Color.red;
                return;
            }
        }
        PuzzleManager.Instance.puzzloRecorteResuelto = true;
        textoFeedback.text = "✓ Correcto. La carta es anterior al recorte. La historia oficial no cierra.";
        textoFeedback.color = Color.green;
    }
}