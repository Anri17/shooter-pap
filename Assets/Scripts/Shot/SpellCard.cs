using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SpellCard : MonoBehaviour
{
    public abstract IEnumerator PlaySpellCard();
}
