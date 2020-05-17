using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using UnityEngine;

public enum WaveType
{
    Normal,
    Boss,
    Dialogue
}

[CreateAssetMenu(fileName = "New Wave", menuName = "Stage/Wave")]
public class StageWave : ScriptableObject
{
    public bool canContinue = false;
    public WaveType waveType = WaveType.Normal;

    public GameObject waveGameObject;

    public float waveTime;
}
