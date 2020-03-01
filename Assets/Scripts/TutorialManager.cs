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

        if (Input.GetKeyDown(KeyCode.Return) && canContinue)
        {
            canContinue = false;
            canContinueMessage.SetActive(false);
            popUpIndex++;
        }
        
        if (popUpIndex == popUps.Length)
        {
            testWave.SetActive(true);
            canContinue = false;
            canContinueMessage.SetActive(false);
        }

        Tutorial();
    }

    void Tutorial()
    {
        CanContinue();
        /*
        if (popUpIndex == 0)
        {
            CanContinue();
        }
        else if (popUpIndex == 1)
        {
            if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
            {
                CanContinue();
            }
        }
        else if (popUpIndex == 2)
        {
            if (Input.GetKey(KeyCode.LeftShift) && (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow)))
            {
                CanContinue();
            }
        }
        else if (popUpIndex == 3)
        {
            CanContinue();
        }
        else if (popUpIndex == 4)
        {
            CanContinue();
        }
        else if (popUpIndex == 5)
        {
            CanContinue();
        }
        else if (popUpIndex == 6)
        {
            CanContinue();
        }
        else if (popUpIndex == 7)
        {
            CanContinue();
        }
        else if (popUpIndex == 8)
        {
            CanContinue();
        }
        else if (popUpIndex == 9)
        {
            CanContinue();
        }
        else if (popUpIndex == 10)
        {
            CanContinue();
        }
        else if (popUpIndex == 11)
        {
            CanContinue();
        }
        */
    }

    void CanContinue()
    {
        canContinue = true;
        canContinueMessage.SetActive(true);
    }
}
