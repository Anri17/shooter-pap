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
    [SerializeField] GameObject manualMenu;
    [SerializeField] AudioClip menuMusicTheme;

    [SerializeField] GameObject[] menus;

    private void Start()
    {
        gameManager = GameManager.Instance;
        musicPlayer = AudioPlayer.Instance;
        gameManager.ResetData();
        musicPlayer.PlayMusic(menuMusicTheme);
        HideAllMenus();
        foreach (GameObject menu in menus)
            if (menu.name.Equals("MainMenu"))
                menu.SetActive(true);
    }

    private void Update()
    {
        // Load test scene
        if (Input.GetKeyDown(KeyCode.Minus))
        {
            SceneManager.LoadScene("_Tests");
        }
    }
    public void HideAllMenus()
    {
        foreach (GameObject menu in menus)
        {
            menu.SetActive(false);
        }
    }

    // display the chosen menu
    public void DisplayMenu(GameObject menu)
    {
        HideAllMenus();
        menu.SetActive(true);
    }

    // ends the program
    public void ExitApplication()
    {
        Application.Quit();
    }

    // starts game
    public void StartMainLevel()
    {
        gameManager.LoadScene(2);
    }

    // starts tutorial
    public void StartTutorialLevel()
    {
        gameManager.LoadScene(1);
    }
}
