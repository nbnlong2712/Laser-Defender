using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public void LoadGame()
    {
        FindObjectOfType<ScoreKeeper>().ResetScore();
        SceneManager.LoadScene("Game");
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void LoadGameOver()
    {
        Invoke("WaitAndLoad", 1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void WaitAndLoad()
    {
        SceneManager.LoadScene("GameOver");
    }
}