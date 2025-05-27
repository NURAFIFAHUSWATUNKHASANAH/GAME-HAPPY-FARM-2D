using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Panggil ini dari tombol Play
    public void PlayGame()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
