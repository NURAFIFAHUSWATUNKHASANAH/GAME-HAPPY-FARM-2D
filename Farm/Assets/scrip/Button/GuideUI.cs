using UnityEngine;

public class GuideUI : MonoBehaviour
{
    public GameObject guidePanel;

    public void TampilkanGuide()
    {
        guidePanel.SetActive(true);
    }

    public void TutupGuide()
    {
        guidePanel.SetActive(false);
    }
}
