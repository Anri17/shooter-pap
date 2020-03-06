using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Dialogue Message", menuName = "Dialogue/DialogueMessage")]
public class DialogueMessage : ScriptableObject
{
    public string personSpeaking;
    [TextArea(3, 10)]
    public string sentence;
}
