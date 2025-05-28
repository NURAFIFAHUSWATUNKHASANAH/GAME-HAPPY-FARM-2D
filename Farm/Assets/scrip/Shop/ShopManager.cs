using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections.Generic;

public class ShopManager : MonoBehaviour
{
    public static ShopManager Instance;

    [Header("UI Koin")]
    public TextMeshProUGUI textKoin;  // Hubungkan ke Text_Koin
    public Image iconKoin;            // (opsional)

    private int totalKoin = 0;

    [Header("Benih")]
    public GameObject seedButtonPrefab;
    public Transform seedSelectionPanel;
    public List<TanamanData> semuaBenih;

    public TileGrowthManager growthManager;
    public PlantingSystem plantingSystem;

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);

        if (plantingSystem == null)
        {
            plantingSystem = FindObjectOfType<PlantingSystem>();
            if (plantingSystem == null)
                Debug.LogError("PlantingSystem tidak ditemukan di scene!");
        }
    }

    private void Start()
    {
        UpdateUI();
    }

    public void TambahKoin(int jumlah)
    {
        totalKoin += jumlah;
        UpdateUI();
    }

    public void KurangiKoin(int jumlah)
    {
        totalKoin = Mathf.Max(0, totalKoin - jumlah);
        UpdateUI();
    }

    public int GetTotalKoin()
    {
        return totalKoin;
    }

    public void UpdateUI()
    {
        if (textKoin != null)
            textKoin.text = totalKoin.ToString();
    }

    public void JualSemuaBarang()
    {
        var items = InventoryManager.Instance.GetItems();
        int totalDapat = 0;

        foreach (var kv in items)
        {
            int harga = ItemPriceDatabase.Instance.GetHarga(kv.Key);
            totalDapat += harga * kv.Value;
        }

        TambahKoin(totalDapat);
        InventoryManager.Instance.ClearInventory();

        Debug.Log($"[Shop] Dapat {totalDapat} koin dari jual semua barang.");
        NotificationManager.Instance.TampilkanNotifikasi($"Berhasil menjual hasil panen dan mendapatkan {totalDapat} koin!");
    }

    public void BeliBenih(string namaBenih)
    {
        Debug.Log($"[Shop] Mencoba beli benih: {namaBenih}");
        if (ItemPriceDatabase.Instance == null)
        {
            Debug.LogError("[Shop] ItemPriceDatabase.Instance belum diinisialisasi!");
            return;
        }

        int harga = ItemPriceDatabase.Instance.GetHarga(namaBenih);
        Debug.Log($"[Shop] Harga benih {namaBenih} adalah {harga}");

        if (totalKoin >= harga)
        {
            KurangiKoin(harga);

            bool sudahAda = false;
            foreach (Transform child in seedSelectionPanel)
            {
                var label = child.GetComponentInChildren<TextMeshProUGUI>();
                if (label != null && label.text == namaBenih)
                {
                    sudahAda = true;
                    break;
                }
            }

            if (sudahAda)
            {
                Debug.Log($"[Shop] Benih {namaBenih} sudah tersedia.");
                return;
            }

            TanamanData data = semuaBenih.Find(d => d.nama == namaBenih);
            if (data == null)
            {
                Debug.LogError($"[Shop] Benih dengan nama {namaBenih} tidak ditemukan di semuaBenih!");
                return;
            }

            if (seedButtonPrefab == null)
            {
                Debug.LogError("[Shop] seedButtonPrefab belum diassign!");
                return;
            }

            GameObject baru = Instantiate(seedButtonPrefab, seedSelectionPanel);
            var controller = baru.GetComponent<SeedButtonController>();
            if (controller == null)
            {
                Debug.LogError("[Shop] SeedButtonController tidak ditemukan di prefab seedButtonPrefab!");
                return;
            }

            controller.Initialize(
                growthManager.daftarTanaman.FindIndex(d => d.nama == namaBenih), // index tanaman
                data,
                plantingSystem
            );

            Debug.Log($"[Shop] {namaBenih} berhasil dibeli dan ditambahkan.");

            // ✅ Menampilkan notifikasi
            NotificationManager.Instance.TampilkanNotifikasi($"{namaBenih} berhasil dibeli!");
        }
        else
        {
            Debug.Log($"[Shop] Koin tidak cukup untuk beli {namaBenih}.");
            NotificationManager.Instance.TampilkanNotifikasi($"Koin tidak cukup untuk membeli {namaBenih}!");
        }
    }
}
