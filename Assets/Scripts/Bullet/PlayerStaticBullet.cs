using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStaticBullet : PlayerBullet
{
    [SerializeField] float _speed = 750.0f;
    [SerializeField] float _damage = 1.0f;

    public override void MoveBullet()
    {
        transform.Translate(Vector3.up * (_speed / 10) * Time.deltaTime);
    }
}
