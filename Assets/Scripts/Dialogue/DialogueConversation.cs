using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Dialogue Conversation", menuName = "Dialogue/DialogueConversation")]

public class DialogueConversation : ScriptableObject
{
    public DialogueMessage[] DialogueMessages;
}
