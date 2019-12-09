using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Data
{
    public static int score = 0;
    public static float powerLevel = 0.0f;
    public static int lives = 3;

    public static void SetData(int newScore, float newPower, int newLives)
    {
        score = newScore;
        powerLevel = newPower;
        lives = newLives;
    }
}
