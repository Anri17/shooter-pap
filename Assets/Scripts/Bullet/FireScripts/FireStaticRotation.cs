using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireStaticRotation : FireBullet
{
    [Header("Fire Static Rotation")]
    [SerializeField] float startDelay = 1f;
    [SerializeField] float fireDelay;
    [SerializeField] int fireCount;
    [SerializeField] float rotationSpeed = 8f;

    Coroutine fireCoroutine;

    float rotationAngle = 0;

    IEnumerator RepeatFire(float startDelay, float fireDelay, int fireCount)
    {
        yield return new WaitForSeconds(startDelay);

        if (fireCount > 0)
        {
            int initialBullet = 0;
            while (initialBullet < fireCount)
            {
                FireRotate();
                yield return new WaitForSeconds(fireDelay);
                initialBullet++;
            }
            StopCoroutine(fireCoroutine);
        }
        else
        {
            while (true)
            {
                FireRotate();
                yield return new WaitForSeconds(fireDelay);
            }
        }
    }

    protected void FireRotate()
    {
        bulletGameObject = Instantiate(_bullet, transform.position, Quaternion.identity);
        bulletScript = bulletGameObject.GetComponent<Bullet>();

        bulletScript.Speed = _speed;
        bulletScript.Angle = _aimOffset + rotationAngle;
        rotationAngle += rotationSpeed;
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
