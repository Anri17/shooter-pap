using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIUpdate : MonoBehaviour
{
    GameObject powerLevelNumber;
    GameObject scoreNumber;

    void Start()
    {
        // assign variables
        powerLevelNumber = GameObject.Find("PowerLevelNumber");
        scoreNumber = GameObject.Find("ScoreNumber");
    }

    void Update()
    {
        // Update Score
        scoreNumber.GetComponent<Text>().text = Data.score.ToString("000,000,000,000");

        // Update Power Level
        powerLevelNumber.GetComponent<Text>().text = Data.powerLevel.ToString("0.##");
    }
}
