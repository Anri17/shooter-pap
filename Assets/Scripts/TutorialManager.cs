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
    private bool resetContinue = true;

    private void Update()
    {
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

        if (resetContinue)
        {
            canContinue = false;
            resetContinue = false;
        }

        if (popUpIndex == 0)
        {
            if (Input.GetKey(KeyCode.Return))
            {
                popUpIndex++;
            }
        }
        else if (popUpIndex == 1)
        {
            if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
            {
                canContinue = true;
                canContinueMessage.SetActive(true);
            }
            if (Input.GetKey(KeyCode.Return) && canContinue)
            {
                resetContinue = true;
                popUpIndex++;
            }
        }
        else if (popUpIndex == 2)
        {
            if (Input.GetKey(KeyCode.LeftShift) && (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow)))
            {
                canContinue = true;
            }
            if (Input.GetKey(KeyCode.Return) && canContinue)
            {
                resetContinue = true;
                popUpIndex++;
            }
        }
    }
}
