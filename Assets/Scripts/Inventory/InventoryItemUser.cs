using UnityEngine;

public class InventoryItemUser : MonoBehaviour
{
    [Header("Item requerido")]
    [SerializeField] private InventoryItem requiredItem;
    [SerializeField] private bool consumeItemOnSuccess = true;

    [Header("Acciones al usar correctamente")]
    [SerializeField] private GameObject[] activateOnSuccess;
    [SerializeField] private GameObject[] deactivateOnSuccess;
    [SerializeField] private string sceneToLoad;

    private bool alreadyUsed;

    private void OnMouseDown()
    {
        UseRequiredItem();
    }

    public void UseRequiredItem()
    {
        if (alreadyUsed)
            return;

        if (requiredItem == null)
        {
            Debug.LogWarning("No hay item requerido asignado.");
            return;
        }

        if (InventoryManager.Instance == null)
        {
            Debug.LogWarning("No hay InventoryManager en la escena.");
            return;
        }

        if (!InventoryManager.Instance.HasItem(requiredItem))
        {
            Debug.Log("Necesitás: " + requiredItem.displayName);
            return;
        }

        alreadyUsed = true;

        if (consumeItemOnSuccess)
            InventoryManager.Instance.RemoveItem(requiredItem);

        foreach (GameObject obj in activateOnSuccess)
        {
            if (obj != null)
                obj.SetActive(true);
        }

        foreach (GameObject obj in deactivateOnSuccess)
        {
            if (obj != null)
                obj.SetActive(false);
        }

        if (!string.IsNullOrWhiteSpace(sceneToLoad))
        {
            if (SceneLoader.Instance != null)
            {
                SceneLoader.Instance.LoadScene(sceneToLoad);
            }
            else
            {
                Debug.LogError("No se encontró SceneLoader. No se puede cargar la escena: " + sceneToLoad);
            }
        }
    }
}
