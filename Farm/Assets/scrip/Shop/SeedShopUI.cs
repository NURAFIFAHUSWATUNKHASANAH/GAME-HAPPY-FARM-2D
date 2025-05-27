using UnityEngine;
using UnityEngine.UI;

public class SeedShopUI : MonoBehaviour
{
    public Button btnStrawberry, btnBlueberry, btnCabai;

    void Start()
    {
        btnStrawberry.onClick.AddListener(() => ShopManager.Instance.BeliBenih("Strawberry"));
        btnBlueberry.onClick.AddListener(() => ShopManager.Instance.BeliBenih("Blueberry"));
        btnCabai.onClick.AddListener(() => ShopManager.Instance.BeliBenih("Cabai"));
    }
}
