using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuManager : MonoBehaviour
{
    public GameObject pauseMenu;

    GameManager gameManager;

    void Awake()
    {
        gameManager = GameManager.Instance;
    }

    public void BackToMainMenu()
    {
        gameManager.LoadScene(0);
        Time.timeScale = 1;
    }

    public void RestartLevel()
    {
        gameManager.LoadScene(1);
        Time.timeScale = 1;
        GameManager.Instance.ResetData();
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }
}
