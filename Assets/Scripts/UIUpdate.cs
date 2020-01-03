﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIUpdate : MonoBehaviour
{
    public GameObject LevelManager;
    public GameObject powerLevelNumber;
    public GameObject scoreNumber;
    public GameObject livesNumber;

    LevelManager levelManagerScript;
    Player playerScript;

    void Start()
    {
        // levelManagerScript = LevelManager.GetComponent<TestLevel>();
        // playerScript = GetComlevelManagerScript.playerScript;
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    void Update()
    {
        // Update Score
        scoreNumber.GetComponent<Text>().text = GameManager.Instance.Score.ToString("000,000,000,000");
        // Update Power Level
        powerLevelNumber.GetComponent<Text>().text = playerScript.powerLevel.ToString("0.##");
        // Update Lives
        livesNumber.GetComponent<Text>().text = playerScript.lives.ToString("#");
    }
}
