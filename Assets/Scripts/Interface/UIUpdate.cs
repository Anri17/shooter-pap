﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIUpdate : MonoBehaviour
{
    public GameObject powerLevelNumber;
    public GameObject scoreNumber;
    public GameObject livesNumber;

    Player player;
    GameManager gameManager;

    void Awake()
    {
        gameManager = GameManager.Instance;
    }


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    void Update()
    {
        // Update Score
        scoreNumber.GetComponent<Text>().text = gameManager.Score.ToString("000,000,000,000");
        // Update Power Level
        powerLevelNumber.GetComponent<Text>().text = player.PowerLevel.ToString("0.##");
        // Update Lives
        livesNumber.GetComponent<Text>().text = player.Lives.ToString("#");
    }
}