using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticBullet : MonoBehaviour
{
    public GameObject bullet;
    public float fireRate = 1.0f;
    public float offset = -90;

    private Quaternion direction;
    private Vector3 target;

    void Start()
    {
        InvokeRepeating("FireBullet", 0.0f, fireRate / 100);
    }

    void FireBullet()
    {
        target = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
        Vector3 difference = target - transform.position;
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        direction = Quaternion.Euler(0f, 0f, rotZ + offset);


        Instantiate(bullet, transform.position, direction);
    }
}
