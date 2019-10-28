using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBullet : MonoBehaviour
{
    // TODO: use unity editor to organise the variables and the inspector
    //       create a function for each type of fireing
    //       use coroutines instead of invoke

    public GameObject bullet; // what object to fire
    public GameObject targetObject; // the fireing target
    public Vector3 targetCoords = new Vector3(0, -1, 0); // the fireing direction
    public bool fireRepeat = false; // fire repeat or not
    public int fireBulletCount = 0; // how many bullets to fire
    public float fireRate; // how long to wait before the next bullet is fired
    public float offset = -90; // the rotation offset of the direction

    int bulletCounter = 0;
    Quaternion direction;
    string targetObjectTag = "";

    // Start is called before the first frame update
    void Start()
    {
        // get and store target object tag
        if (targetObject != null)
        {
            targetObjectTag = targetObject.tag;
        }

        // fire the bullet
        InvokeRepeating("Fire", 0.0f, fireRate / 100);
    }

    Quaternion GetDirection() // define the direction of the bullet
    {
        if (!targetObjectTag.Equals("")) // define object with tag extracted
        {
            targetObject = GameObject.FindGameObjectWithTag(targetObjectTag);
        }
        
        if (targetObject != null) // set the direction if there's a game object to target
        {
            Vector3 difference = targetObject.transform.position - transform.position;
            float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
            return Quaternion.Euler(0f, 0f, rotZ + offset);
        }
        else // otherwise set the direction based on coordinates given
        {
            Vector3 target = transform.position + targetCoords;
            Vector3 difference = target - transform.position;
            float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
            return Quaternion.Euler(0f, 0f, rotZ + offset);
        }
    }

    void Fire()
    {
        direction = GetDirection(); // assign direction of the bullet

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