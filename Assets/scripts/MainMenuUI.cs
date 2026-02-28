using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("Battle"); // tên scene chơi
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}