using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingShootBullet : MonoBehaviour
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
        direction = Quaternion.LookRotation(target.transform.position - transform.position);
        direction.z = 0;
        


        Instantiate(bullet, transform.position, direction);
    }
}
