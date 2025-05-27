using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileGrowthManager : MonoBehaviour
{
    public Tilemap tanamanTilemap; // Tambahan: Tilemap tanaman
    public List<TanamanData> daftarTanaman;

    private Dictionary<Vector3Int, int> tileStages = new Dictionary<Vector3Int, int>();
    private Dictionary<Vector3Int, TanamanData> tileTanamanData = new Dictionary<Vector3Int, TanamanData>();

    public void TanamBenih(Vector3 worldPos, int indexTanaman)
    {
        if (indexTanaman < 0 || indexTanaman >= daftarTanaman.Count) return;

        Vector3Int cellPos = tanamanTilemap.WorldToCell(worldPos);

        if (!tileStages.ContainsKey(cellPos))
        {
            TanamanData data = daftarTanaman[indexTanaman];
            tanamanTilemap.SetTile(cellPos, data.stage1);
            tileStages[cellPos] = 1;
            tileTanamanData[cellPos] = data;

            StartCoroutine(GrowTile(cellPos, data));
        }
    }

    IEnumerator GrowTile(Vector3Int cellPos, TanamanData data)
    {
        yield return new WaitForSeconds(2f);
        tanamanTilemap.SetTile(cellPos, data.stage2);
        tileStages[cellPos] = 2;

        yield return new WaitForSeconds(2f);
        tanamanTilemap.SetTile(cellPos, data.stage3);
        tileStages[cellPos] = 3;

        yield return new WaitForSeconds(2f);
        tanamanTilemap.SetTile(cellPos, data.stage4);
        tileStages[cellPos] = 4;

        yield return new WaitForSeconds(2f);
        tanamanTilemap.SetTile(cellPos, data.stage5);
        tileStages[cellPos] = 5;
    }

    public TanamanData GetTanamanData(Vector3Int pos)
    {
        if (tileTanamanData.ContainsKey(pos))
            return tileTanamanData[pos];
        return null;
    }

    public int GetStage(Vector3Int pos)
    {
        if (tileStages.ContainsKey(pos))
            return tileStages[pos];
        return 0;
    }

    public bool AdaTanaman(Vector3Int pos)
    {
        return tileTanamanData.ContainsKey(pos);
    }

    public void HapusDataTanaman(Vector3Int pos)
    {
        tileStages.Remove(pos);
        tileTanamanData.Remove(pos);
    }
}
