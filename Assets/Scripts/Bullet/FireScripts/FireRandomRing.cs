using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class FireRandomRing : FireBullet
{
    [Header("Fire Ring")]
    [SerializeField] int directions = 8;
    [SerializeField] float startDelay = 1f;
    [SerializeField] float fireDelay;
    [SerializeField] int fireCount;

    Coroutine fireCoroutine;

    void FireRandom(Vector3 position)
    {
        bulletGameObject = Instantiate(_bullet, position, Quaternion.identity);
        bulletScript = bulletGameObject.GetComponent<Bullet>();

        bulletScript.Speed = _speed;
        bulletScript.Angle = _aimOffset + GetAngle(_target);
    }

    public Vector3 GetRandomPoint()
    {
        float randX = Random.Range((GameManager.GAME_FIELD_TOP_LEFT.x) + GameManager.GAME_FIELD_CENTER.x, (GameManager.GAME_FIELD_TOP_RIGHT.x) + GameManager.GAME_FIELD_CENTER.x);
        float randY = Random.Range(1, (GameManager.GAME_FIELD_TOP_LEFT.y));

        return new Vector3(randX, randY, 0);
    }

    IEnumerator RepeatFire(float startDelay, float fireDelay, int fireCount)
    {
        yield return new WaitForSeconds(startDelay);

        if (fireCount > 0)
        {
            int initialBullet = 0;
            Vector3 randomPos = GetRandomPoint();
            while (initialBullet < fireCount)
            {
                float currentAngle = 0;
                while (currentAngle < 360)
                {
                    FireRandom(randomPos);

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
                Vector3 randomPos = GetRandomPoint();
                while (currentAngle < 360)
                {
                    FireRandom(randomPos);

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
            Debug.Log("I'm in the play field");
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
