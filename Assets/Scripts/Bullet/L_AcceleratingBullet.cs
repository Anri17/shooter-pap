using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L_AcceleratingBullet : L_Bullet
{
    [SerializeField] float _minSpeed = 10.0f;
    [SerializeField] float _maxSpeed = 80.0f;
    [SerializeField] float _delayBeforeTransition = 320.0f;
    [SerializeField] float _transitionSpeed = 10.0f;
    
    float _speed;

    private void Start()
    {
        _speed = _minSpeed;
    }

    public override void MoveBullet()
    {
        transform.Translate(Vector3.up * (_speed / 10) * Time.deltaTime);

        if (!(_delayBeforeTransition <= 0))
        {
            _delayBeforeTransition--;
        }

        if ((_speed < _maxSpeed) && _delayBeforeTransition <= 0)
        {
            _speed += _transitionSpeed;
            if (_speed > _maxSpeed)
            {
                _speed = _maxSpeed * Time.deltaTime;
            }
        }
    }
}
