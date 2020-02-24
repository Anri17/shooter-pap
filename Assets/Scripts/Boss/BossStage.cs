using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Boss Stage", menuName = "Boss/Stage")]
public class BossStage : ScriptableObject
{
    public float health;
    public float deathTimer;
    public GameObject barrage;
    public Transform path;
    public float pathSpeed;
    public int powerItemsToDrop = 2;
    public int bigPowerItemsToDrop = 1;
    public int scoreItemsToDrop = 8;
}
