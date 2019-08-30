﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject bullet;

    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            Instantiate(bullet, transform.position + new Vector3(0, 0.7f, 0), bullet.transform.rotation);
        }
    }
}
