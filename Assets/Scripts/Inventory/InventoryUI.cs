using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] private InventoryManager inventoryManager;
    [SerializeField] private InventorySlotUI[] slots;

    private bool subscribed;

    private void Start()
    {
        ConnectToInventory();
        SetupSlots();
        RefreshUI();
    }

    private void OnEnable()
    {
        ConnectToInventory();
        RefreshUI();
    }

    private void OnDisable()
    {
        if (inventoryManager != null && subscribed)
        {
            inventoryManager.InventoryChanged -= RefreshUI;
            inventoryManager.SelectionChanged -= RefreshUI;
            subscribed = false;
        }
    }

    private void ConnectToInventory()
    {
        if (inventoryManager == null)
            inventoryManager = InventoryManager.Instance;

        if (inventoryManager != null && !subscribed)
        {
            inventoryManager.InventoryChanged += RefreshUI;
            inventoryManager.SelectionChanged += RefreshUI;
            subscribed = true;
        }
    }

    private void SetupSlots()
    {
        if (slots == null)
            return;

        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i] != null)
                slots[i].Setup(this, i);
        }
    }

    public void OnSlotClicked(int index)
    {
        if (inventoryManager == null)
            inventoryManager = InventoryManager.Instance;

        if (inventoryManager != null)
            inventoryManager.ClickSlot(index);
    }

    public void RefreshUI()
    {
        if (inventoryManager == null)
            inventoryManager = InventoryManager.Instance;

        if (inventoryManager == null || slots == null)
            return;

        for (int i = 0; i < slots.Length; i++)
        {
            InventoryItem item = null;

            if (i < inventoryManager.Items.Count)
                item = inventoryManager.Items[i];

            bool selected = inventoryManager.SelectedIndex == i;

            if (slots[i] != null)
                slots[i].SetItem(item, selected);
        }
    }
}
