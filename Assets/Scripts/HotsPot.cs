using UnityEngine;

public class Hotspot : MonoBehaviour
{
    public string sceneDestino;
    public Texture2D cursorInteractivo;

    void OnMouseEnter()
    {
        if (cursorInteractivo != null)
            Cursor.SetCursor(cursorInteractivo, Vector2.zero, CursorMode.Auto);
    }

    void OnMouseExit()
    {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }

    void OnMouseDown()
    {
        if (sceneDestino != "")
        {
            Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
            SceneLoader.Instance.LoadScene(sceneDestino);
        }
    }
}