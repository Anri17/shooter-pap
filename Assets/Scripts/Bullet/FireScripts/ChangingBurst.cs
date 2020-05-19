using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangingBurst : FireBullet
{
    [Header("Changing Burst")]
    [Tooltip("The speed of the first bullet")]
    [SerializeField] float _initialSpeed = 10.0f;
    [Tooltip("The speed of the last bullet")]
    [SerializeField] float _finalSpeed = 80.0f;
    [Tooltip("How fast the transition is")]
    [SerializeField] float _transitionSpeed = 10.0f;
    [Tooltip("How many bullets to fire")]
    [SerializeField] int _bulletCount;

    private void Start()
    {
        _speed = _initialSpeed;
        StartCoroutine(RepeatFire(0.5f));
    }

    IEnumerator RepeatFire(float time)
    {
        while(true)
        {
            Fire();
            yield return new WaitForSeconds(time);
        }
    }
}
