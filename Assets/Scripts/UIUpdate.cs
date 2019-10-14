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
        powerLevelNumber = GameObject.Find("PowerLevelNumber");
        scoreNumber = GameObject.Find("ScoreNumber");
    }

    void Update()
    {
        scoreNumber.GetComponent<Text>().text = Data.score.ToString("n3");
        powerLevelNumber.GetComponent<Text>().text = Data.powerLevel.ToString("0.##");
        Debug.Log("Collected");
    }
}
