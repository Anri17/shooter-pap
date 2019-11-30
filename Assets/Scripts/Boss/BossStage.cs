using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Boss Stage", menuName = "Boss/Stage")]
public class BossStage : ScriptableObject
{
    public float health;
    public GameObject barrage;
}
