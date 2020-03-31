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
    [SerializeField] GameObject creditsMenu;
    [SerializeField] GameObject musicRoom;
    [SerializeField] AudioClip menuMusicTheme;

    private void Start()
    {
        gameManager = GameManager.Instance;
        musicPlayer = AudioPlayer.Instance;
        gameManager.ResetData();
        musicPlayer.PlayMusic(menuMusicTheme);
        DisplayMainMenu();
    }

    private void Update()
    {
        // Load test scene
        if (Input.GetKeyDown(KeyCode.Minus))
        {
            SceneManager.LoadScene("_Tests");
        }
    }
    public void HideAll()
    {
        mainMenu.SetActive(false);
        playMenu.SetActive(false);
        optionsMenu.SetActive(false);
        creditsMenu.SetActive(false);
        musicRoom.SetActive(false);
    }

    public void DisplayMainMenu()
    {
        HideAll();
        mainMenu.SetActive(true);
    }

    public void DisplayPlayMenu()
    {
        HideAll();
        playMenu.SetActive(true);
    }

    public void DisplayOptionsMenu()
    {
        HideAll();
        optionsMenu.SetActive(true);
    }

    public void DisplayMusicRoom()
    {
        HideAll();
        musicRoom.SetActive(true);
    }

    public void DisplayCreditsMenu()
    {
        HideAll();
        creditsMenu.SetActive(true);
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
