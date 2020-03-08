using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    public GameObject pauseMenu;

    public bool canOpenMenu;

    void Awake()
    {
        canOpenMenu = true;
        pauseMenu.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && canOpenMenu)
        {
            TogglePauseGame();
        }
    }

    public void TogglePauseGame()
    {
        if (pauseMenu.activeSelf)
        {
            Time.timeScale = 1;
            pauseMenu.SetActive(false);
            GameManager.LockCursor();
        }
        else
        {
            Time.timeScale = 0;
            pauseMenu.SetActive(true);
            GameManager.UnlockCursor();
        }
    }
}
