using UnityEngine;
using UnityEngine.SceneManagement;

public class Temporizador : MonoBehaviour
{
    public static Temporizador Instance;

    [SerializeField] private float tiempoLimite = 3600f;
    private float tiempoTranscurrido = 0f;
    private bool corriendo = false;
    private bool finalAlternativoDisparado = false;

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

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void Start()
    {
        IniciarTemporizador();
    }

    void Update()
    {
        if (!corriendo || finalAlternativoDisparado) return;

        tiempoTranscurrido += Time.deltaTime;

        if (tiempoTranscurrido >= tiempoLimite)
        {
            corriendo = false;
            finalAlternativoDisparado = true;
            DispararFinalAlternativo();
        }
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "MainMenu")
        {
            Destroy(gameObject);
        }
    }

    public void IniciarTemporizador()
    {
        tiempoTranscurrido = 0f;
        corriendo = true;
        finalAlternativoDisparado = false;
    }

    public float GetTiempoTranscurrido()
    {
        return tiempoTranscurrido;
    }

    public bool EstaCorriendo()
    {
        return corriendo;
    }

    private void DispararFinalAlternativo()
    {
        SceneManager.LoadScene("MainMenu");
    }
}