using UnityEngine;
using UnityEngine.Tilemaps;

[System.Serializable]
public class TanamanData
{
    public string nama;
    public Sprite icon;         // ikon yang dipakai di tombol UI
    public TileBase stage1;     // benih
    public TileBase stage2;     // tunas
    public TileBase stage3;     // daun
    public TileBase stage4;     // bunga
    public TileBase stage5;     // siap panen
}
