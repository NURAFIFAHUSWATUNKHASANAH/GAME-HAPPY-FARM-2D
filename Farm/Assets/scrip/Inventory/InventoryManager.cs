// File: Assets/Scripts/Inventory/InventoryManager.cs
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;
    private Dictionary<string, int> itemDictionary = new Dictionary<string, int>();

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public void TambahItem(string namaItem)
    {
        if (itemDictionary.ContainsKey(namaItem))
            itemDictionary[namaItem]++;
        else
            itemDictionary[namaItem] = 1;

        Debug.Log($"[Inventory] Added {namaItem}, total: {itemDictionary[namaItem]}");
        UI_Inventory.Instance.UpdateUI(itemDictionary);
    }
    public void ClearInventory()
{
    itemDictionary.Clear();
    UI_Inventory.Instance.UpdateUI(itemDictionary);
}


    public Dictionary<string, int> GetItems() => itemDictionary;
}
