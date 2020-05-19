using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticBullet : L_Bullet
{
    [SerializeField] float _speed;

    public override void MoveBullet()
    {
        transform.Translate(Vector3.up * (_speed / 10) * Time.deltaTime);
    }
}
