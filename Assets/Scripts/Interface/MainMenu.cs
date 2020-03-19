﻿using System.Collections;
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

    public void HideAll()
    {
        mainMenu.SetActive(false);
        playMenu.SetActive(false);
        optionsMenu.SetActive(false);
        bottomRightPannel.SetActive(false);
        middlePannel.SetActive(false);
        musicRoom.SetActive(false);
    }

    public void DisplayMainMenu()
    {
        HideAll();
        mainMenu.SetActive(true);
        DisplayBottomRightPannel();
    }

    public void DisplayPlayMenu()
    {
        HideAll();
        playMenu.SetActive(true);
        DisplayMiddlePannel();
    }

    public void DisplayOptionsMenu()
    {
        HideAll();
        optionsMenu.SetActive(true);
        DisplayMiddlePannel();
    }

    public void DisplayMusicRoom()
    {
        HideAll();
        musicRoom.SetActive(true);
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
