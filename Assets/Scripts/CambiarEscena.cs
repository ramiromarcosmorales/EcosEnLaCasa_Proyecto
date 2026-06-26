using UnityEngine;
using UnityEngine.SceneManagement;

public class CambiarEscena : MonoBehaviour
{
    public string sceneDestino;

    public void Ir()
    {
        SceneManager.LoadScene(sceneDestino);
    }
}