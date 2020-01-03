using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerBullet : Bullet
{
    [SerializeField] float _damage = 0.0f;

    public float Damage
    {
        get => _damage;
        set => _damage = value;
    }

    private void Start()
    {
        Damage = _damage;
    }
}
