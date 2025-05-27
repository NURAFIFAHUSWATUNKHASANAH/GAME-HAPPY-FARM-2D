using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SeedButtonController : MonoBehaviour
{
    public Image iconImage;
    public TextMeshProUGUI label;

    private int tanamanIndex;
    private PlantingSystem plantingSystem;

    public void Initialize(int indexTanamanDiGrowthManager, TanamanData data, PlantingSystem ps)
    {
        tanamanIndex = indexTanamanDiGrowthManager;
        plantingSystem = ps;

        label.text = data.nama;
        iconImage.sprite = data.icon;
        iconImage.enabled = true;

        GetComponent<Button>().onClick.AddListener(OnClick);
    }

    private void OnClick()
    {
        plantingSystem.SelectSeed(tanamanIndex);
    }
}
