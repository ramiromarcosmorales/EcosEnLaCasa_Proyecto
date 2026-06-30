using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    [SerializeField] private InventoryItem item;
    [SerializeField] private bool destroyOnPickup = true;

    private void OnMouseDown()
    {
        PickUp();
    }

    public void PickUp()
    {
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

        bool added = InventoryManager.Instance.AddItem(item);

        if (added && destroyOnPickup)
            Destroy(gameObject);
    }
}