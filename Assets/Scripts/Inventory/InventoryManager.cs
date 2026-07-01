using System;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance { get; private set; }

    [Serializable]
    public class ItemCombination
    {
        public InventoryItem firstItem;
        public InventoryItem secondItem;
        public InventoryItem resultItem;

        public bool Matches(InventoryItem a, InventoryItem b)
        {
            return (a == firstItem && b == secondItem) ||
                   (a == secondItem && b == firstItem);
        }
    }

    [Header("Configuración")]
    [SerializeField] private int maxSlots = 6;

    [Header("Combinaciones posibles")]
    [SerializeField] private List<ItemCombination> combinations = new List<ItemCombination>();

    private readonly List<InventoryItem> items = new List<InventoryItem>();

    public event Action InventoryChanged;
    public event Action SelectionChanged;

    public IReadOnlyList<InventoryItem> Items => items;
    public int MaxSlots => maxSlots;
    public int SelectedIndex { get; private set; } = -1;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public bool AddItem(InventoryItem item)
    {
        if (item == null)
        {
            Debug.LogWarning("No se puede agregar un item nulo al inventario.");
            return false;
        }

        if (items.Count >= maxSlots)
        {
            Debug.Log("Inventario lleno.");
            return false;
        }

        items.Add(item);
        InventoryChanged?.Invoke();
        return true;
    }

    public bool HasItem(InventoryItem item)
    {
        return item != null && items.Contains(item);
    }

    public bool RemoveItem(InventoryItem item)
    {
        if (item == null)
            return false;

        int removedIndex = items.IndexOf(item);

        if (removedIndex == -1)
            return false;

        items.RemoveAt(removedIndex);

        if (SelectedIndex == removedIndex)
        {
            SelectedIndex = -1;
        }
        else if (removedIndex < SelectedIndex)
        {
            SelectedIndex--;
        }

        if (SelectedIndex >= items.Count)
            SelectedIndex = -1;

        InventoryChanged?.Invoke();
        SelectionChanged?.Invoke();

        return true;
    }

    public void ClickSlot(int index)
    {
        if (index < 0 || index >= maxSlots)
            return;

        if (index >= items.Count)
        {
            SelectedIndex = -1;
            SelectionChanged?.Invoke();
            return;
        }

        if (SelectedIndex == -1)
        {
            SelectedIndex = index;
            SelectionChanged?.Invoke();
            return;
        }

        if (SelectedIndex == index)
        {
            SelectedIndex = -1;
            SelectionChanged?.Invoke();
            return;
        }

        bool combined = TryCombine(SelectedIndex, index);

        if (!combined)
        {
            SelectedIndex = index;
            SelectionChanged?.Invoke();
        }
    }

    private bool TryCombine(int firstIndex, int secondIndex)
    {
        if (firstIndex < 0 || secondIndex < 0)
            return false;

        if (firstIndex >= items.Count || secondIndex >= items.Count)
            return false;

        InventoryItem firstItem = items[firstIndex];
        InventoryItem secondItem = items[secondIndex];

        foreach (ItemCombination combination in combinations)
        {
            if (combination == null || combination.resultItem == null)
                continue;

            if (combination.Matches(firstItem, secondItem))
            {
                int higherIndex = Mathf.Max(firstIndex, secondIndex);
                int lowerIndex = Mathf.Min(firstIndex, secondIndex);

                items.RemoveAt(higherIndex);
                items.RemoveAt(lowerIndex);

                items.Add(combination.resultItem);

                SelectedIndex = -1;

                Debug.Log("Combinación creada: " + combination.resultItem.displayName);

                InventoryChanged?.Invoke();
                SelectionChanged?.Invoke();

                return true;
            }
        }

        Debug.Log("Estos objetos no se pueden combinar.");
        return false;
    }
}
