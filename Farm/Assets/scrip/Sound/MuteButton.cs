using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MuteButton : MonoBehaviour
{
    private Button tombolMute;

    [Header("Komponen UI")]
    public TextMeshProUGUI textTombol; // Optional: jika ingin menampilkan teks
    public Image ikonTombol;

    [Header("Gambar Ikon")]
    public Sprite speakerOn;
    public Sprite speakerOff;

    void Start()
    {
        tombolMute = GetComponent<Button>();
        tombolMute.onClick.AddListener(ToggleMute);

        UpdateTampilan();
    }

    void ToggleMute()
    {
        bool muted = !BacksoundManager.Instance.IsMuted();
        BacksoundManager.Instance.Mute(muted);
        UpdateTampilan();
    }

    void UpdateTampilan()
    {
        bool muted = BacksoundManager.Instance.IsMuted();

        if (ikonTombol != null)
        {
            ikonTombol.sprite = muted ? speakerOff : speakerOn;
        }

        if (textTombol != null)
        {
            textTombol.text = muted ? "Unmute" : "Mute";
        }
    }
}
