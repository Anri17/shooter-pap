using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L_FireBullet : MonoBehaviour
{
    public GameObject bullet; // what bullet to fire
    public GameObject target; // the target direction
    public bool fireLimitedCount = false; // fire repeatedly or a defined count
    public int fireBulletCount = 0; // how many bullets to fire in total
    public float fireRate = 1; // how long to wait before the next bullet is fired
    public float aimOffset = 0; // the rotation offset of the aim direction
    public float shotDelay = 0;
    public float shotLoopDelay = 0; // how long to wait between each loop
    public bool randomizeShotVelocity = false;
    public bool randomDirection = false;

    int bulletsFired = 0; // how many bullets fired so far
    Quaternion direction; // the direction to aim at
    string targetTag = "";

    void Awake()
    {
        if (target.CompareTag("Player"))
        {
            targetTag = "Player";
            target = GameObject.FindGameObjectWithTag(targetTag);
        }
    }

    void Start()
    {
        if (randomizeShotVelocity)
        {
            fireRate = Random.Range(0.8f, 1.6f);
            aimOffset = Random.Range(-0.4f, 0.4f);
        }

        StartCoroutine(StartShot(shotDelay));
    }

    // Stop firing when this gameobjects exits the play area
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag.Equals("PlayArea"))
        {
            CancelInvoke();
        }
    }

    // Get the direction of the bullet
    Quaternion GetDirection()
    {
        if (randomDirection)
        {
            aimOffset = Random.Range(-180, 180);
        }

        if (target != null) // run only if target exists
        {
            Vector3 difference = target.transform.position - transform.position;
            float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
            return Quaternion.Euler(0f, 0f, rotZ - 90 + aimOffset);
        }
        else if (targetTag.Equals("Player")) // fix target if player is the target (ie when player dies, player turns null, so reasign target)
        {
            target = GameObject.FindGameObjectWithTag(targetTag);

            if (target != null)
            {
                Vector3 difference = target.transform.position - transform.position;
                float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
                return Quaternion.Euler(0f, 0f, rotZ - 90 + aimOffset);
            }
            return Quaternion.Euler(0f, 0f, 180 + aimOffset); // if player is not yet set, fire to player spawn point
        }
        return Quaternion.Euler(0f, 0f, 180 + aimOffset); // if there's no target, fire straight down
    }

    void Fire()
    {
        if (fireLimitedCount == false) // fire bullets forever
        {
            direction = GetDirection();
            Instantiate(bullet, transform.position, direction);
        }
        else // fire a determined count of bullets
        {
            direction = GetDirection();
            Instantiate(bullet, transform.position, direction);
            bulletsFired++;
            if (bulletsFired >= fireBulletCount)
            {
                CancelInvoke("Fire");
            }
        }
    }

    IEnumerator ShotLoopDelayCount(float time)
    {
        bulletsFired = 0;
        InvokeRepeating("Fire", 0.0f, fireRate);
        yield return new WaitForSeconds(time);
        CancelInvoke("Fire");
        StartCoroutine(ShotLoopDelayCount(shotLoopDelay));
    }

    IEnumerator StartShot(float time)
    {
        yield return new WaitForSeconds(time);
        if (bullet != null)
        {
            if (shotLoopDelay <= 0)
            {
                InvokeRepeating("Fire", 0.0f, fireRate);
            }
            else
            {
                StartCoroutine(ShotLoopDelayCount(shotLoopDelay));
            }
        }
    }
}