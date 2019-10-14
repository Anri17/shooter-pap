using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootBullet : MonoBehaviour
{
    public GameObject bullet;
    public float fireInterval = 1.0f;

    void Start()
    {
        InvokeRepeating("FireBullet", 0.0f, fireInterval);
    }

    void FireBullet()
    {
        Instantiate(bullet, transform.position, Quaternion.LookRotation(new Vector3(0, -1, 0)));
    }
}
