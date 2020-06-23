using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossManager : MonoBehaviour
{

    [SerializeField] private GameObject bossInterface;
    [SerializeField] private GameObject bossHealthBar;
    [SerializeField] private GameObject bossStageCount;
    [SerializeField] private GameObject bossDeathTimer;

    [HideInInspector] public GameObject spawnedBoss;

    private void Update()
    {
        if (bossInterface.activeSelf)
        {
            UpdateBossHUD();
        }
    }

    private void UpdateBossHUD()
    {
        if (spawnedBoss != null)
        {
            // Update HP Bar
            bossHealthBar.GetComponent<Slider>().value = spawnedBoss.GetComponent<Boss>().CurrentHealth / spawnedBoss.GetComponent<Boss>().CurrentMaxHealth;

            // Update Current Stage Number
            bossStageCount.GetComponent<Text>().text = spawnedBoss.GetComponent<Boss>().StageCount.ToString();

            // Update Death Timer
            bossDeathTimer.GetComponent<Text>().text = spawnedBoss.GetComponent<Boss>().CurrentDeathTimer.ToString();
        }
    }

    public void ActivateBossInterface()
    {
        bossInterface.SetActive(true);
    }

    public void DeactivateBossInterface()
    {
        bossInterface.SetActive(false);
    }

}
