using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject MainMenuScreen;
    public GameObject PlayScreen;
    public GameObject TutorialScreen;
    public GameObject OptionsScreen;
    public AudioClip menuMusicTheme;

    private void Awake()
    {
        MainMenuScreen.SetActive(true);
        PlayScreen.SetActive(false);
        TutorialScreen.SetActive(false);
        OptionsScreen.SetActive(false);
    }

    private void Start()
    {
        GameManager.Instance.ResetData();
        MusicPlayer.Instance.PlayMusic(menuMusicTheme);
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
