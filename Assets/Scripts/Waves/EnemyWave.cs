﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy Wave", menuName = "Stage/Enemy Wave")]
public class EnemyWave : Wave
{
    [SerializeField] GameObject wave;
    [SerializeField] float delayTime;

    public GameObject Wave { get => wave; }
    public float DelayStartTime { get => delayTime; }
}
