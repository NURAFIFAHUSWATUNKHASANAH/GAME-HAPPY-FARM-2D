using System.Collections;
using UnityEngine;
using TMPro;

public class NotificationManager : MonoBehaviour
{
    public static NotificationManager Instance;

    public GameObject panelNotifikasi;
    public TextMeshProUGUI teksNotifikasi;
    public float delaySebelumMuncul = 1f;
    public float durasiTampil = 2f;

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);

        panelNotifikasi.SetActive(false);
    }

    public void TampilkanNotifikasi(string pesan)
    {
        StartCoroutine(RunNotifikasi(pesan));
    }

    private IEnumerator RunNotifikasi(string pesan)
    {
        yield return new WaitForSeconds(delaySebelumMuncul);

        teksNotifikasi.text = pesan;
        panelNotifikasi.SetActive(true);

        yield return new WaitForSeconds(durasiTampil);

        panelNotifikasi.SetActive(false);
    }
}
