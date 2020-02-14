using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Boss Wave", menuName = "Boss/Wave")]
public class BossWave : ScriptableObject
{
    [SerializeField] GameObject boss;
    [SerializeField] BossStage[] bossStages;


}
