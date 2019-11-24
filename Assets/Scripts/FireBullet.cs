using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBullet : MonoBehaviour
{
    public GameObject bullet; // what bullet to fire
    public GameObject target; // the target direction
    public bool fireLimitedCount = false; // fire repeatedly or a defined count
    public int fireBulletCount = 0; // how many bullets to fire in total
    public float fireRate = 1f; // how long to wait before the next bullet is fired
    public float aimOffset = 0; // the rotation offset of the aim direction

    int bulletsFired = 0; // how many bullets fired so far
    Quaternion direction; // the direction to aim at

    void Update()
    {
        // fire the bullet
        InvokeRepeating("Fire", 0.0f, fireRate);
    }

    // stop firing when this gameobjects exits the play area
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("PlayArea"))
        {
            CancelInvoke();
        }
    }

    // Get the direction of the bullet
    Quaternion GetDirection()
    {
        Vector3 difference = target.transform.position - transform.position;
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        return Quaternion.Euler(0f, 0f, rotZ - 90 + aimOffset);
    }

    void Fire()
    {
        direction = GetDirection();

        if (!fireLimitedCount) // fire bullets forever
        {
            Instantiate(bullet, transform.position, direction);
        }
        else // fire a determined count of bullet
        {
            Instantiate(bullet, transform.position, direction);
            if (++bulletsFired >= fireBulletCount)
            {
                CancelInvoke("Fire");
            }
        }
    }
}