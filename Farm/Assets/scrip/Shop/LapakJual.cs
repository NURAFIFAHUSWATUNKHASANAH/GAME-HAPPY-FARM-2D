using UnityEngine;

public class LapakJual : MonoBehaviour
{
    private bool sudahTerjual = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !sudahTerjual)
        {
            ShopManager.Instance.JualSemuaBarang(); // Sudah ada notifikasi di dalam sini
            NotificationManager.Instance.TampilkanNotifikasi("Menjual semua panen..."); // (opsional, notifikasi tambahan)
            sudahTerjual = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            sudahTerjual = false;
        }
    }
}
