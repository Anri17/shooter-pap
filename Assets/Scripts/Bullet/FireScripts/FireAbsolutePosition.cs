using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class FireAbsolutePosition : MonoBehaviour
{
    [SerializeField] GameObject spell;
    [SerializeField] float delay;


    GameObject spawnedSpell;

    void Start()
    {
        StartCoroutine(spawnSpellCoroutine());
    }

    IEnumerator spawnSpellCoroutine()
    {
        yield return new WaitForSeconds(delay);
        spawnedSpell = Instantiate(spell, transform.position, Quaternion.identity);
    }

    void OnDestroy()
    {
        Destroy(spawnedSpell);
    }
}
