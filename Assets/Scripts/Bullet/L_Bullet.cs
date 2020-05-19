using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class L_Bullet : MonoBehaviour
{
    private void Update()
    {
        MoveBullet();
    }

    public abstract void MoveBullet();
}
