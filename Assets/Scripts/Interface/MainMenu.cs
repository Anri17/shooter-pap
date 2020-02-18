using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    GameManager gameManager;
    AudioPlayer musicPlayer;

    [SerializeField] GameObject mainMenu;
    [SerializeField] GameObject playMenu;
    [SerializeField] GameObject optionsMenu;
    [SerializeField] GameObject bottomRightPannel;
    [SerializeField] GameObject middlePannel;
    [SerializeField] AudioClip menuMusicTheme;

    private void Start()
    {
        gameManager = GameManager.Instance;
        musicPlayer = AudioPlayer.Instance;
        gameManager.ResetData();
        musicPlayer.PlayMusic(menuMusicTheme);
        DisplayMainMenu();
    }

    public void DisplayMainMenu()
    {
        mainMenu.SetActive(true);
        playMenu.SetActive(false);
        optionsMenu.SetActive(false);
        DisplayBottomRightPannel();
    }

    public void DisplayPlayMenu()
    {
        mainMenu.SetActive(false);
        playMenu.SetActive(true);
        optionsMenu.SetActive(false);
        DisplayMiddlePannel();
    }

    public void DisplayOptionsMenu()
    {
        mainMenu.SetActive(false);
        playMenu.SetActive(false);
        optionsMenu.SetActive(true);
        DisplayMiddlePannel();
    }

    void DisplayBottomRightPannel()
    {
        bottomRightPannel.SetActive(true);
        middlePannel.SetActive(false);
    }

    void DisplayMiddlePannel()
    {
        bottomRightPannel.SetActive(false);
        middlePannel.SetActive(true);
    }

    public void ExitApplication()
    {
        Application.Quit();
    }

    public void StartMainLevel()
    {
        gameManager.LoadScene(2);
    }

    public void StartTutorialLevel()
    {
        gameManager.LoadScene(1);
    }
}
