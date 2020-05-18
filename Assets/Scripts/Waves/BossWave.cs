using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Boss Wave", menuName = "Stage/Boss Wave")]
public class BossWave : Wave
{
    [SerializeField] GameObject _boss;
    [SerializeField] DialogueConversation dialogue1;
    [SerializeField] DialogueConversation dialogue2;
    [SerializeField] float endDelay = 1f;

    public GameObject Boss { get => _boss; }
    public DialogueConversation Dialogue1 { get => dialogue1; }
    public DialogueConversation Dialogue2 { get => dialogue2; }
    public float EndDelay { get => endDelay; }
}
