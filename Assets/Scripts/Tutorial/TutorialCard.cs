using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new tutorial card", menuName = "Tutorial/Tutorial Card")]
public class TutorialCard : ScriptableObject
{
    public GameObject mainObject;
    public float secondsToLast;
}
