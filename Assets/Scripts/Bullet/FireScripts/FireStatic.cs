using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class FireStatic : FireBullet
{
    [Header("Fire Static")]
    [SerializeField] float startDelay = 1f;
    [SerializeField] float fireDelay;
    [SerializeField] int fireCount;

    Coroutine fireCoroutine;

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

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayArea"))
        {
            fireCoroutine = StartCoroutine(RepeatFire(startDelay, fireDelay, fireCount));
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayArea"))
        {
            StopCoroutine(fireCoroutine);
        }
    }
}
