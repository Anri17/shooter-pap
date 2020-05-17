using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Boss Stage", menuName = "Boss/Stage")]
public class L_BossStage : ScriptableObject
{
    public int scoreWorth = 100000;
    public float health;
    public float deathTimer;
    public GameObject barrage;
    public bool randomMovement = false;
    public Transform path;
    public float pathSpeed;
    public int powerItemsToDrop = 2;
    public int bigPowerItemsToDrop = 1;
    public int scoreItemsToDrop = 8;
    public int lifeItemsToDrop = 0;
    public int bombItemsToDrop = 0;
}
