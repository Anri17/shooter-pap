using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Boss Wave", menuName = "Stage/Boss Wave")]
public class BossWave : Wave
{
    [SerializeField] GameObject _boss;

    public GameObject Boss { get => _boss; }
}
