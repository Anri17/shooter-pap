using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIUpdate : MonoBehaviour
{
    public GameObject powerLevelNumber;
    public GameObject scoreNumber;
    public GameObject livesNumber;

    void Update()
    {
        // Update Score
        scoreNumber.GetComponent<Text>().text = GameManager.Instance.score.ToString("000,000,000,000");
        // Update Power Level
        powerLevelNumber.GetComponent<Text>().text = GameManager.Instance.powerLevel.ToString("0.##");
        // Update Lives
        livesNumber.GetComponent<Text>().text = GameManager.Instance.lives.ToString("#");
    }
}
