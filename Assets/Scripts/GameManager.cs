using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public long score = 0;
    public float powerLevel = 0.0f;
    public int lives = 3;

    void Awake()
    {
        MakeSingleton();
    }

    private void MakeSingleton()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetData(long newScore, float newPower, int newLives)
    {
        score = newScore;
        powerLevel = newPower;
        lives = newLives;
    }

    public void ResetData()
    {
        score = 0;
        powerLevel = 0.0f;
        lives = 3;
    }
}
