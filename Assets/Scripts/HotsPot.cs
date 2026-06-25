using UnityEngine;

public class Hotspot : MonoBehaviour
{
    public string sceneDestino;

    void OnMouseEnter()
    {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }

    void OnMouseExit()
    {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }

    void OnMouseDown()
    {
        if (sceneDestino != "")
        {
            SceneLoader.Instance.LoadScene(sceneDestino);
        }
    }
}