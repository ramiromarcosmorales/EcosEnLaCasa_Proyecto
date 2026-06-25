using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public static SceneLoader Instance;

    public delegate void OnSceneChanged(string sceneName);
    public static event OnSceneChanged SceneChangedEvent;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void LoadScene(string sceneName)
    {
        SceneChangedEvent?.Invoke(sceneName);
        SceneManager.LoadScene(sceneName);
    }
}