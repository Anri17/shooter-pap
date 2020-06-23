using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireRing : FireBullet
{
    [Header("Fire Ring")]
    [SerializeField] int directions = 8;
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
                float currentAngle = 0;
                while(currentAngle < 360)
                {
                    Fire();

                    bulletScript.Angle = _aimOffset + GetAngle(_target) + currentAngle;
                    currentAngle += GetRingAngle();
                }
                
                yield return new WaitForSeconds(fireDelay);
                initialBullet++;
            }
            StopCoroutine(fireCoroutine);
        }
        else
        {
            while (true)
            {
                float currentAngle = 0;
                while (currentAngle < 360)
                {
                    Fire();

                    bulletScript.Angle = _aimOffset + GetAngle(_target) + currentAngle;
                    currentAngle += GetRingAngle();
                }

                yield return new WaitForSeconds(fireDelay);
            }
        }
    }

    int GetRingAngle()
    {
        if (directions <= 0)
        {
            directions = 1;
        }

        return 360 / directions;
    }

    bool stay = false;
    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayArea") && stay == false)
        {
            fireCoroutine = StartCoroutine(RepeatFire(startDelay, fireDelay, fireCount));
            stay = true;
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
