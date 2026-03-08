using UnityEngine;
using UnityEngine.SceneManagement;

public class BattleFlow : MonoBehaviour
{
    public GameObject gameOverUI;
    public GameObject gameWinUI;
    public PlayerHealth playerHealth;
    public GameObject bgMusic;

    public int enemyToWin = 10;   // ⭐ cần giết 10 con

    bool isGameEnded = false;

    void Start()
    {
        gameOverUI.SetActive(false);
        gameWinUI.SetActive(false);

        EnemyHealth.TotalEnemyKilled = 0;   // reset kill count
        playerHealth.onDead += OnGameOver;
    }

    void Update()
    {
        if (isGameEnded) return;

        if (EnemyHealth.TotalEnemyKilled >= enemyToWin)
        {
            OnGameWin();
        }
    }

    void OnGameOver()
    {
        if (isGameEnded) return;
        isGameEnded = true;

        gameOverUI.SetActive(true);
        if (bgMusic) bgMusic.SetActive(false);
        Time.timeScale = 0f;
    }

    void OnGameWin()
    {
        if (isGameEnded) return;
        isGameEnded = true;

        gameWinUI.SetActive(true);
        if (bgMusic) bgMusic.SetActive(false);
        playerHealth.gameObject.SetActive(false);
        Time.timeScale = 0f;
    }

    public void ReturnToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    public void RestartLevel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}