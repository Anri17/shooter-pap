using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Bullet : MonoBehaviour
{
    private void Update()
    {
        MoveBullet();
    }

    public abstract void MoveBullet();
}
