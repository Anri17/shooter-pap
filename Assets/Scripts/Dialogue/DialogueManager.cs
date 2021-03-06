﻿using System;
using System.Runtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public GameObject dialogueScreen;
    public Text nameText;
    public Text dialogueText;

    public Queue<DialogueMessage> dialogue;

    public bool dialogueEnded = true;

    [SerializeField] BossManager bossManager;

    private void Awake()
    {
        dialogueScreen.SetActive(false);
        dialogue = new Queue<DialogueMessage>();
    }

    private void Start()
    {
        dialogueText.text = "";
        nameText.text = "";
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) && !dialogueEnded)
        {
            RunThroughDialogue();
        }
    }

    public void StartDialogue(DialogueConversation dialogueConversation)
    {
        dialogueText.text = "";
        nameText.text = "";
        dialogueEnded = false;
        dialogueScreen.SetActive(true);
        dialogue.Clear();
        UnpackDialogue(dialogueConversation);
        StartCoroutine(WaitSeconds(RunThroughDialogue, 1));
    }

    public void UnpackDialogue(DialogueConversation dialogueConversation)
    {
        foreach (DialogueMessage message in dialogueConversation.DialogueMessages)
        {
            dialogue.Enqueue(message);
        }
    }

    public void DisplayMessage(string name, string message)
    {
        StopAllCoroutines();
        nameText.text = name;
        StartCoroutine(TypeMessage(message));
    }

    IEnumerator TypeMessage(string sentence)
    {
        dialogueText.text = "";

        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }

    void EndDialogue()
    {
        nameText.text = "";
        dialogueText.text = "";
        dialogueScreen.SetActive(false);
        dialogueEnded = true;
    }

    void RunThroughDialogue()
    {
        if (dialogue.Count != 0)
        {
            DialogueMessage currentMessage = dialogue.Dequeue();
            string name = currentMessage.personSpeaking;
            string message = currentMessage.sentence;
            DisplayMessage(name, message);
            if (currentMessage.changeMusic)
            {
                GameObject.Find("LevelManager").GetComponent<LevelManager>().PlayBossMusic(1);
            }

            if (currentMessage.presentBoss)
            {
                bossManager.spawnedBoss.GetComponent<Boss>().MoveToDefaultPosition();
            }
        }
        else
        {
            EndDialogue();
        }
    }

    IEnumerator WaitSeconds(Action methodToRun, float secondsToWait)
    {
        yield return new WaitForSeconds(secondsToWait);
        methodToRun();
    }
}
