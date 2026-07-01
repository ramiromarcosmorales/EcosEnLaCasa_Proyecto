using UnityEngine;
using UnityEngine.EventSystems;

public class ItemPickup : MonoBehaviour
{
    [SerializeField] private InventoryItem item;
    [SerializeField] private bool destroyOnPickup = true;

    private bool alreadyPickedUp;

    private void OnMouseDown()
    {
        if (IsPointerOverUI())
            return;

        PickUp();
    }

    public void PickUp()
    {
        if (alreadyPickedUp)
            return;

        if (item == null)
        {
            Debug.LogWarning("Este objeto no tiene un InventoryItem asignado.");
            return;
        }

        if (InventoryManager.Instance == null)
        {
            Debug.LogWarning("No hay InventoryManager en la escena.");
            return;
        }

        alreadyPickedUp = true;

        bool added = InventoryManager.Instance.AddItem(item);

        if (!added)
        {
            alreadyPickedUp = false;
            return;
        }

        if (destroyOnPickup)
            Destroy(gameObject);
    }

    private bool IsPointerOverUI()
    {
        if (EventSystem.current == null)
            return false;

        if (EventSystem.current.IsPointerOverGameObject())
            return true;

        for (int i = 0; i < Input.touchCount; i++)
        {
            if (EventSystem.current.IsPointerOverGameObject(Input.GetTouch(i).fingerId))
                return true;
        }

        return false;
    }
}