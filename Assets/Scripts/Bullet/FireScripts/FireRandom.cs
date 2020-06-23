using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireRandom : FireBullet
{
    [Header("Fire Random")]
    [SerializeField] float startDelay = 1f;
    [SerializeField] float fireDelay;
    [SerializeField] int fireCount;

    Coroutine fireCoroutine;

    void Fire()
    {
        bulletGameObject = Instantiate(_bullet, transform.position, Quaternion.identity);
        bulletScript = bulletGameObject.GetComponent<Bullet>();

        bulletScript.Speed = _speed;
        bulletScript.Angle = _aimOffset + GetRandomAngle();
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
            while (true)
            {
                Fire();
                yield return new WaitForSeconds(fireDelay);
            }
        }
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

    float GetRandomAngle()
    {
        return Random.Range(-180, 180);
    }
}
