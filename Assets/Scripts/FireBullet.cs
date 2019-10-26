using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBullet : MonoBehaviour
{
    public GameObject bullet;
    public GameObject targetObject;
    public Vector3 targetCoords = new Vector3(0, -1, 0);
    public bool fireRepeat = false;
    public int fireBulletCount = 0;
    public float fireRate;
    public float offset = -90;

    int bulletCounter = 0;
    Quaternion direction;

    // Start is called before the first frame update
    void Start()
    {
        // fire the bullet
        InvokeRepeating("Fire", 0.0f, fireRate / 100);
    }

    void Fire()
    {
        // define the direction of the bullet
        if (targetObject != null)   // set the direction if there's a game object to target
        {
            Vector3 difference = targetObject.transform.position - transform.position;
            float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
            direction = Quaternion.Euler(0f, 0f, rotZ + offset);
        }
        else // otherwise set the direction based on coordinates given
        {
            Vector3 target = transform.position + targetCoords;
            Vector3 difference = target - transform.position;
            float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
            direction = Quaternion.Euler(0f, 0f, rotZ + offset);
        }

        if (fireRepeat) // fire bullets indefinitely, or until the object is destroyed
        {
            Instantiate(bullet, transform.position, direction);
        }
        else // fire a determined ammount of bullet
        {
            Instantiate(bullet, transform.position, direction);
            if (++bulletCounter >= fireBulletCount)
            {
                CancelInvoke("Fire");
            }
        }
    }
}
