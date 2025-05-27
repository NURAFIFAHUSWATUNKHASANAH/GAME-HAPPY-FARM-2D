using System.Collections.Generic;
using UnityEngine;

public class ItemPriceDatabase : MonoBehaviour
{
    public static ItemPriceDatabase Instance;
    private Dictionary<string, int> hargaItem = new Dictionary<string, int>()
    {
        { "Labu", 10 },
        { "Wortel", 5 },
        { "Tomat", 8 },
        { "Strawberry", 12 },
        { "Blueberry", 12 },
        { "Cabai", 14 }
    };

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public int GetHarga(string namaItem) =>
        hargaItem.ContainsKey(namaItem) ? hargaItem[namaItem] : 0;
}
