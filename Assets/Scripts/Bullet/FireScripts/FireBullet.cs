using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBullet : MonoBehaviour
{
    [Header("Base")]
    [SerializeField] protected GameObject _bullet;
    [SerializeField] protected Transform _target;
    [SerializeField] protected float _aimOffset;
    [SerializeField] protected float _speed;

    protected GameObject bulletGameObject;
    protected Bullet bulletScript;

    protected void Fire()
    {
        bulletGameObject = Instantiate(_bullet, transform.position, Quaternion.identity);
        bulletScript = bulletGameObject.GetComponent<Bullet>();

        bulletScript.Speed = _speed;
        bulletScript.Angle = _aimOffset + GetAngle(_target);
    }

    protected float GetAngle(Transform target)
    {
        // We give the player prefab, but we need the actual player, so we need to scan the playfield for it
        if (target != null && target.CompareTag("Player")) 
        {
            target = GameObject.FindGameObjectWithTag("Player").transform;
        }

        if (target != null)
        {
            Vector3 dir = target.position - transform.position;
            dir = target.InverseTransformDirection(dir);
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg + 90;

            Debug.Log("bullet angle " + angle);
            Debug.Log($"Player Position: {target.position}");
            Debug.Log($"Up Position: {transform.position + Vector3.up}");
            return angle;
        }
        return 0f;
    }
}
