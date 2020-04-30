﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _FireBullet : MonoBehaviour
{
    [Header("Base Class")]
    [SerializeField] protected GameObject _bullet;
    [SerializeField] protected Transform _target;
    [SerializeField] protected float _aimOffset;
    [SerializeField] protected float _speed;

    protected void Fire()
    {
        GameObject bulletGameObject = Instantiate(_bullet, transform.position, Quaternion.identity);
        _Bullet bulletScript = bulletGameObject.GetComponent<_Bullet>();

        bulletScript.Speed = _speed;
        bulletScript.Angle = _aimOffset + GetAngle(_target);
    }

    float GetAngle(Transform target)
    {
        // We give the player prefab, but we need the actual player, so we need to scan the playfield for it
        if (target.CompareTag("Player")) 
        {
            target = GameObject.FindGameObjectWithTag("Player").transform;
        }

        if (target != null)
        {
            float angle = Vector3.Angle(Vector3.up, target.position);
            if (target.position.x < 0)
                angle = -Mathf.Abs(angle);
            Debug.Log("bullet angle " + angle);
            return angle;
        }
        return 0f;
    }
}
