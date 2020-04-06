using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    public GameObject[] popUps;
    public GameObject canContinueMessage;
    private int popUpIndex;
    public GameObject testWave;
    public bool canContinue = false;

    GameManager gameManager;

    private void Awake()
    {
        gameManager = GameManager.Instance;
    }

    private void Start()
    {
        StartCoroutine(CanContinue(2f));
    }

    private void Update()
    {
        gameManager.spawnedPlayer.GetComponent<Player>().Lives = 10;

        for (int i = 0; i < popUps.Length; i++)
        {
            if (i == popUpIndex)
            {
                popUps[i].SetActive(true);
            }
            else
            {
                popUps[i].SetActive(false);
            }
        }

        if (Input.GetKeyDown(KeyCode.Return) && canContinue)
        {
            canContinue = false;
            canContinueMessage.SetActive(false);
            popUpIndex++;
            StartCoroutine(CanContinue(2f));
        }
        
        if (popUpIndex == popUps.Length)
        {
            testWave.SetActive(true);
            canContinue = false;
            canContinueMessage.SetActive(false);
        }
    }

    IEnumerator CanContinue(float secondsToWait)
    {
        yield return new WaitForSeconds(secondsToWait);
        if (popUpIndex == popUps.Length)
        {
            canContinue = false;
            canContinueMessage.SetActive(false);
        }
        else
        {
            canContinue = true;
            canContinueMessage.SetActive(true);
        }
    }
}
