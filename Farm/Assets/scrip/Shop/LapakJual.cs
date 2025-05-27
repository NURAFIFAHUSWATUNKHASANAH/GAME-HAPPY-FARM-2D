using UnityEngine;

public class LapakJual : MonoBehaviour
{
    private bool sudahTerjual = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !sudahTerjual)
        {
            ShopManager.Instance.JualSemuaBarang();
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
