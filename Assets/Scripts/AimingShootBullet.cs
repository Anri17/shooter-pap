using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimingShootBullet : MonoBehaviour
{
    public GameObject bullet;
    public GameObject target;
    public float fireInterval = 1.0f;
    private Quaternion direction;

    void Start()
    {
        InvokeRepeating("FireBullet", 0.0f, fireInterval);
    }

    void FireBullet()
    {
        if (target != null)
        {
            direction = Quaternion.LookRotation(target.transform.position - transform.position);
            Debug.Log(direction);


            Instantiate(bullet, transform.position, direction);

        }
    }
}
