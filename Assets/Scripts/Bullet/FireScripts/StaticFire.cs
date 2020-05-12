using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticFire : _FireBullet
{
    [Header("Static Fire")]
    [SerializeField] float startDelay;
    [SerializeField] float fireDelay;
    [SerializeField] int fireCount;

    Coroutine fireCoroutine;

    private void Start()
    {
        fireCoroutine = StartCoroutine(RepeatFire(startDelay, fireDelay, fireCount));
    }

    void Update()
    {
        Fire();
    }

    IEnumerator RepeatFire(float startDelay, float fireDelay, int fireCount)
    {
        yield return new WaitForSeconds(startDelay);

        if (fireCount > 0)
        {
            int initialBullet = 0;
            while (initialBullet < fireCount)
            {
                Fire();
                yield return new WaitForSeconds(fireDelay);
                initialBullet++;
            }
            StopCoroutine(fireCoroutine);
        }
        else
        {
            Fire();
            yield return new WaitForSeconds(fireDelay);
        }
    } 
}
