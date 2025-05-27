using UnityEngine;
using UnityEngine.UI;

public class BenihShopUI : MonoBehaviour
{
    [Header("Tombol Beli")]
    public Button tombolBeliWortel;
    public Button tombolBeliTomat;
    public Button tombolBeliLabu;

    void Start()
    {
        tombolBeliWortel.onClick.AddListener(() => BeliBenih("Wortel"));
        tombolBeliTomat.onClick.AddListener(() => BeliBenih("Tomat"));
        tombolBeliLabu.onClick.AddListener(() => BeliBenih("Labu"));
    }

    void BeliBenih(string namaBenih)
    {
        int harga = ItemPriceDatabase.Instance.GetHarga(namaBenih);
        if (ShopManager.Instance.GetTotalKoin() >= harga)
        {
            ShopManager.Instance.KurangiKoin(harga);
            InventoryManager.Instance.TambahItem(namaBenih);
            Debug.Log($"[ShopBenih] Beli benih {namaBenih} seharga {harga} koin.");
        }
        else
        {
            Debug.Log($"[ShopBenih] Tidak cukup koin untuk beli {namaBenih}!");
        }
    }
}
