using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TokoBenih : MonoBehaviour
{
    public GameObject shopPanel;

    public void BukaShop()
    {
        shopPanel.SetActive(true);
    }

    public void TutupShop()
    {
        shopPanel.SetActive(false);
    }
}
