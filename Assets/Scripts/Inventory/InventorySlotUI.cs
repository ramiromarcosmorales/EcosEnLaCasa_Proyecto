using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlotUI : MonoBehaviour
{
    [Header("Referencias UI")]
    [SerializeField] private TMP_Text itemNameText;
    [SerializeField] private Image iconImage;
    [SerializeField] private GameObject selectedMarker;

    private InventoryUI inventoryUI;
    private int slotIndex;

    private void Awake()
    {
        Button button = GetComponent<Button>();

        if (button != null)
            button.onClick.AddListener(HandleClick);
    }

    public void Setup(InventoryUI ui, int index)
    {
        inventoryUI = ui;
        slotIndex = index;
    }

    public void SetItem(InventoryItem item, bool selected)
    {
        if (item == null)
        {
            if (itemNameText != null)
                itemNameText.text = "";

            if (iconImage != null)
            {
                iconImage.sprite = null;
                iconImage.enabled = false;
            }

            if (selectedMarker != null)
                selectedMarker.SetActive(false);

            return;
        }

        if (itemNameText != null)
            itemNameText.text = item.displayName;

        if (iconImage != null)
        {
            iconImage.sprite = item.icon;
            iconImage.enabled = item.icon != null;
        }

        if (selectedMarker != null)
            selectedMarker.SetActive(selected);
    }

    private void HandleClick()
    {
        if (inventoryUI != null)
            inventoryUI.OnSlotClicked(slotIndex);
    }
}
