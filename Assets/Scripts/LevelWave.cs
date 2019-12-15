using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy Wave", menuName = "Level/Enemy Wave")]
public class LevelWave : ScriptableObject
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] int enemyNumber = 5;

    public GameObject GetEnemyPrefab() => enemyPrefab;

    public int GetEnemyNumber() => enemyNumber;
}
