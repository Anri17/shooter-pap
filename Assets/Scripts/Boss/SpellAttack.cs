using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Spell Attack", menuName = "Boss/Spell Attack")]
public class SpellAttack : ScriptableObject
{
    [Header("Details")]
    public int scoreWorth = 100000;
    public float health;
    public float deathTimer;
    public GameObject spellAttack;
    [Header("Drop Count")]
    public int powerItems = 2;
    public int bigPowerItems = 1;
    public int scoreItems = 8;
    public int lifeItems = 0;
    public int bombItems = 0;
}
