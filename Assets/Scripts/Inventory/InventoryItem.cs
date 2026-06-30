using UnityEngine;

public enum InventoryItemType
{
    Narrativo,
    Funcional
}

[CreateAssetMenu(fileName = "NewInventoryItem", menuName = "Ecos En La Casa/Inventory Item")]
public class InventoryItem : ScriptableObject
{
    public string itemId;
    public string displayName;

    [TextArea(2, 5)]
    public string description;

    public Sprite icon;
    public InventoryItemType itemType = InventoryItemType.Funcional;
}
