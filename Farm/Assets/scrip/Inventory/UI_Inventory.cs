// File: Assets/Scripts/Inventory/UI_Inventory.cs
using System.Collections.Generic;
using UnityEngine;

public class UI_Inventory : MonoBehaviour
{
    public static UI_Inventory Instance;

    [Header("Slot Prefab & Parent")]
    public GameObject slotTemplate; 
    public Transform slotParent;    

    [Header("Item Sprites")]
    public Sprite labuSprite;
    public Sprite wortelSprite;
    public Sprite tomatSprite;
    public Sprite strawberrySprite;
    public Sprite blueberrySprite;
    public Sprite cabaiSprite;

    private Dictionary<string, Sprite> spriteDatabase = new Dictionary<string, Sprite>();
    private List<GameObject> spawnedSlots = new List<GameObject>();

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);

        spriteDatabase["Labu"]   = labuSprite;
        spriteDatabase["Wortel"] = wortelSprite;
        spriteDatabase["Tomat"]  = tomatSprite;
        spriteDatabase["Strawberry"]  = strawberrySprite;
        spriteDatabase["Blueberry"]  = blueberrySprite;
        spriteDatabase["Cabai"]  = cabaiSprite;
    }

    public void UpdateUI(Dictionary<string, int> items)
    {
        // clear old
        foreach (var go in spawnedSlots) Destroy(go);
        spawnedSlots.Clear();

        // spawn new
        foreach (var kv in items)
        {
            GameObject slot = Instantiate(slotTemplate, slotParent);
            slot.SetActive(true);
            var cs = slot.GetComponent<InventorySlot>();
            if (spriteDatabase.TryGetValue(kv.Key, out var spr))
                cs.SetSlot(spr, kv.Value);
            else
                cs.ClearSlot();
            spawnedSlots.Add(slot);
        }
    }
}
