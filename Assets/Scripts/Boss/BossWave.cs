using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Boss Wave", menuName = "Boss/Wave")]
public class BossWave : ScriptableObject
{
    [SerializeField] float _startDelay;
    [SerializeField] float _endDelay;
    [SerializeField] GameObject _boss;

    public float StartDelay { get => _startDelay; }
    public float EndDelay { get => _endDelay; }
    public GameObject Boss { get => _boss; }
}
