using UnityEngine;
using UnityEngine.SceneManagement;

public class CambiarEscena : MonoBehaviour
{
    public string sceneDestino;

    public void Ir()
    {
        if (SceneLoader.Instance != null)
        {
            SceneLoader.Instance.LoadScene(sceneDestino);
        }
        else
        {
            SceneManager.LoadScene(sceneDestino);
        }
    }
}