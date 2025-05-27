using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;
using System.Collections.Generic;

public class PlantingSystem : MonoBehaviour
{
    [Header("Tilemaps")]
    public Tilemap tanahTanamTilemap;
    public TileGrowthManager growthManager;

    [Header("UI Seed Selection")]
    public GameObject seedSelectionPanel;   // Panel di Canvas
    public GameObject seedButtonPrefab;     // Prefab tombol

    private int selectedSeedIndex = 0;

    // Hanya 3 benih awal yang langsung tersedia
    public List<string> benihAwal = new List<string> { "Labu", "Wortel", "Tomat" };

    private void Start()
    {
        // 1) Clear semua tombol yang ada
        foreach (Transform child in seedSelectionPanel.transform)
            Destroy(child.gameObject);

        // 2) Tampilkan hanya benih yang termasuk dalam benihAwal
        for (int i = 0; i < growthManager.daftarTanaman.Count; i++)
        {
            var data = growthManager.daftarTanaman[i];

            if (benihAwal.Contains(data.nama))
            {
                GameObject btn = Instantiate(seedButtonPrefab, seedSelectionPanel.transform);
                var ctrl = btn.GetComponent<SeedButtonController>();
                ctrl.Initialize(i, data, this);
            }
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Vector3Int pos = tanahTanamTilemap.WorldToCell(transform.position);
            if (tanahTanamTilemap.HasTile(pos) && !growthManager.AdaTanaman(pos))
            {
                growthManager.TanamBenih(transform.position, selectedSeedIndex);
            }
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            Vector3Int pos = tanahTanamTilemap.WorldToCell(transform.position);
            if (growthManager.AdaTanaman(pos))
            {
                int stage = growthManager.GetStage(pos);
                TanamanData data = growthManager.GetTanamanData(pos);

                if (stage == 5)
                {
                    Debug.Log("[Panen] " + data.nama + " berhasil dipanen.");
                    InventoryManager.Instance.TambahItem(data.nama);
                    growthManager.tanamanTilemap.SetTile(pos, null); // Hapus tile
                    growthManager.HapusDataTanaman(pos);
                }
                else
                {
                    Debug.Log("[Panen] Belum siap dipanen.");
                }
            }
        }
    }

    // Dipanggil SeedButtonController
    public void SelectSeed(int idx)
    {
        selectedSeedIndex = idx;
        Debug.Log("Benih dipilih: " + growthManager.daftarTanaman[idx].nama);
    }


    // === DIPANGGIL TOMBOL UI TANAM ===
public void ButtonTanam()
{
    Vector3Int pos = tanahTanamTilemap.WorldToCell(transform.position);
    if (tanahTanamTilemap.HasTile(pos) && !growthManager.AdaTanaman(pos))
    {
        growthManager.TanamBenih(transform.position, selectedSeedIndex);
        Debug.Log("[Tanam] Benih " + growthManager.daftarTanaman[selectedSeedIndex].nama + " ditanam.");
    }
    else
    {
        Debug.Log("[Tanam] Tidak bisa tanam di sini.");
    }
}

// === DIPANGGIL TOMBOL UI PANEN ===
public void ButtonPanen()
{
    Vector3Int pos = tanahTanamTilemap.WorldToCell(transform.position);
    if (growthManager.AdaTanaman(pos))
    {
        int stage = growthManager.GetStage(pos);
        TanamanData data = growthManager.GetTanamanData(pos);

        if (stage == 5)
        {
            Debug.Log("[Panen] " + data.nama + " berhasil dipanen.");
            InventoryManager.Instance.TambahItem(data.nama);
            growthManager.tanamanTilemap.SetTile(pos, null);
            growthManager.HapusDataTanaman(pos);
        }
        else
        {
            Debug.Log("[Panen] Tanaman belum siap dipanen.");
        }
    }
    else
    {
        Debug.Log("[Panen] Tidak ada tanaman di sini.");
    }
}

}
