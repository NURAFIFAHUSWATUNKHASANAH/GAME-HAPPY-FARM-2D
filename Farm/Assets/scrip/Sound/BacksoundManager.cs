using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class BacksoundManager : MonoBehaviour
{
    public static BacksoundManager Instance;

    private AudioSource audioSrc;
    private bool isMuted = false;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Agar tidak hilang saat pindah scene
        }
        else
        {
            Destroy(gameObject);
        }

        audioSrc = GetComponent<AudioSource>();
    }

    public void Mute(bool mute)
    {
        isMuted = mute;
        audioSrc.mute = mute;
        Debug.Log("[BacksoundManager] Backsound " + (mute ? "Dimatikan" : "Dinyalakan"));
    }

    public bool IsMuted() => isMuted;
}
