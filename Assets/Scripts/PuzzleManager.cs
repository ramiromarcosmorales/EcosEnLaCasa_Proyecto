using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    public static PuzzleManager Instance;

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

    public bool puzzloCajaResuelto = false;
    public bool puzzloListaResuelto = false;
    public bool puzzloRecorteResuelto = false;
    public bool puzzloRetratoResuelto = false;

    public bool TodosResueltos()
    {
        return puzzloCajaResuelto && puzzloListaResuelto &&
               puzzloRecorteResuelto && puzzloRetratoResuelto;
    }
}