using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    GameManager gameManager;
    MusicPlayer musicPlayer;

    [SerializeField] GameObject MainMenuScreen;
    [SerializeField] GameObject PlayScreen;
    [SerializeField] GameObject TutorialScreen;
    [SerializeField] GameObject OptionsScreen;
    [SerializeField] AudioClip menuMusicTheme;

    private void Start()
    {
        gameManager = GameManager.Instance;
        musicPlayer = MusicPlayer.Instance;
        gameManager.ResetData();
        musicPlayer.PlayMusic(menuMusicTheme);
        DisplayMainMenuScreen();
    }

    public void DisplayMainMenuScreen()
    {
        MainMenuScreen.SetActive(true);
        PlayScreen.SetActive(false);
        TutorialScreen.SetActive(false);
        OptionsScreen.SetActive(false);
    }

    public void DisplayPlayScreen()
    {
        MainMenuScreen.SetActive(false);
        PlayScreen.SetActive(true);
        TutorialScreen.SetActive(false);
        OptionsScreen.SetActive(false);
    }

    public void DisplayTutorialScreen()
    {
        MainMenuScreen.SetActive(false);
        PlayScreen.SetActive(false);
        TutorialScreen.SetActive(true);
        OptionsScreen.SetActive(false);
    }
    public void DisplayOptionsScreen()
    {
        MainMenuScreen.SetActive(false);
        PlayScreen.SetActive(false);
        TutorialScreen.SetActive(false);
        OptionsScreen.SetActive(true);
    }

    public void ExitApplication()
    {
        Application.Quit();
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Play");
    }
}
