using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLv1BarrageShoot : MonoBehaviour
{
    public GameObject bulletFront;
    public GameObject bulletLeft;
    public GameObject bulletRight;
    float delayTime = 1.0f;



    void Start()
    {
        Invoke("Shoot", delayTime);
    }

    void Shoot()
    {
        Instantiate(bulletFront, transform);
        Instantiate(bulletLeft, transform);
        Instantiate(bulletRight, transform);
        Invoke("Shoot", delayTime);
    }
}
