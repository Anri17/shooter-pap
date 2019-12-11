using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuNavigator : MonoBehaviour
{
    public GameObject MainMenuScreen;
    public GameObject PlayScreen;
    public GameObject TutorialScreen;
    public GameObject OptionsScreen;

    private void Awake()
    {
        MainMenuScreen.SetActive(true);
        PlayScreen.SetActive(false);
        TutorialScreen.SetActive(false);
        OptionsScreen.SetActive(false);
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
        SceneManager.LoadScene("Play");
        GameManager.Instance.SetData(0, 0.0f, 3);
        /*
        MainMenuScreen.SetActive(false);
        PlayScreen.SetActive(true);
        TutorialScreen.SetActive(false);
        OptionsScreen.SetActive(false);
        */
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
}
