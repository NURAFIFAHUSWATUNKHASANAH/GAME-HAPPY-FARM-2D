using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventorySlot : MonoBehaviour
{
    [Header("UI References")]
    public Image icon;
    public TextMeshProUGUI amountText;

    public void SetSlot(Sprite itemSprite, int amount)
    {
        icon.sprite = itemSprite;
        icon.enabled = true;
        amountText.text = "x" + amount;
    }

    public void ClearSlot()
    {
        icon.enabled = false;
        icon.sprite = null;
        amountText.text = "";
    }
}
