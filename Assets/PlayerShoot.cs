using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject bullet;

    void FixedUpdate()
    {
        if (Input.GetButton("Fire1"))
        {
            Instantiate(bullet, transform.position + new Vector3(0, 0.7f, 0), bullet.transform.rotation);
        }
    }
}
