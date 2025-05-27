using UnityEngine;

[System.Serializable]
public class ItemData
{
    public string nama;
    public Sprite icon;
    public int jumlah;

    public ItemData(string nama, Sprite icon, int jumlah = 1)
    {
        this.nama = nama;
        this.icon = icon;
        this.jumlah = jumlah;
    }
}
