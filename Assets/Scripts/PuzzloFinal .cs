using UnityEngine;
using TMPro;

public class PuzzloFinal : MonoBehaviour
{
    public TextMeshProUGUI textoFeedback;
    public GameObject accesoSotano;

    public void IntentarAbrir()
    {
        if (!PuzzleManager.Instance.TodosResueltos())
        {
            textoFeedback.text = "✗ Falta resolver puzzles en otras habitaciones.";
            textoFeedback.color = Color.red;
            return;
        }

        // Código final: combinación de pistas
        // Fecha Jorge (1952) + Año desaparición (1979) = 19521979
        textoFeedback.text = "✓ Las tablas del living ceden. El sótano está abierto.";
        textoFeedback.color = Color.green;

        if (accesoSotano != null)
            accesoSotano.SetActive(true);

        // Navegar al sótano
        SceneLoader.Instance.LoadScene("Sotano");
    }
}