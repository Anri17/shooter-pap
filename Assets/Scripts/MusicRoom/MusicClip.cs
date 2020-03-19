using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Music Clip", menuName = "Music/MusicClip")]
public class MusicClip : ScriptableObject
{
    public string musicTitle;
    public AudioClip musicClip;
    [TextArea(4, 8)]
    public string composerComment;
}
