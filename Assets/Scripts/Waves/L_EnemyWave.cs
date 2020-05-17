using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy Wave", menuName = "Level/Legacy Enemy Wave")]
public class L_EnemyWave : ScriptableObject
{
    [SerializeField] GameObject wave;
    [SerializeField] float delayTime;

    public GameObject Wave { get => wave; }
    public float DelayStartTime { get => delayTime; }
}
