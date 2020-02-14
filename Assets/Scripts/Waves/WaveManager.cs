using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    [SerializeField] float startDelay = 2f;
    [SerializeField] EnemyWave[] waves;

    GameObject[] spawnedWaves;

    void Start()
    {
        spawnedWaves = new GameObject[waves.Length];
        StartCoroutine(PlayLevel(startDelay, waves));
    }

    IEnumerator PlayLevel(float waitBeforeStart, EnemyWave[] waves)
    {
        yield return new WaitForSeconds(waitBeforeStart);
        for (int i = 0; i < waves.Length; i++)
        {
            Debug.Log($"Launching Wave {i + 1}");
            spawnedWaves[i] = Instantiate(waves[i].Wave, transform);
            yield return new WaitForSeconds(waves[i].DelayStartTime);
        }
        Debug.Log("Level Ended");
    }
}
