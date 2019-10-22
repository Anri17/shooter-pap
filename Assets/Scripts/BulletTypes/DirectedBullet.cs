using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectedBullet : MonoBehaviour
{
    public GameObject bullet;
    public GameObject target;
    public float fireRate = 1.0f;
    public float offset = -90;

    private Quaternion direction;

    void Start()
    {
        InvokeRepeating("FireBullet", 0.0f, fireRate / 100);
    }

    void FireBullet()
    {
        if (target != null)
        {
            // direction = Quaternion.LookRotation(target.transform.position - transform.position);
            // Debug.Log(direction);

            Vector3 difference = target.transform.position - transform.position;
            float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
            direction = Quaternion.Euler(0f, 0f, rotZ + offset);

            Instantiate(bullet, transform.position, direction);
        }
    }
}
