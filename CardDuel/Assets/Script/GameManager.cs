using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverWinUI;
    public GameObject gameOverLoseUI;

    public void GameOverWin()
    {
        gameOverWinUI.SetActive(true);
        AudioManager.instance.PlaySFX("Win");
        Time.timeScale = 0f;
    }

    public void GameOverLose()
    {
        gameOverLoseUI.SetActive(true);
        AudioManager.instance.PlaySFX("Lose");
        Time.timeScale = 0f;
    }

    public void GoMainMenuGame()
    {
        gameOverWinUI.SetActive(false);
        gameOverLoseUI.SetActive(false);
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenuScene");
    }
}
