using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed = 10;
    [SerializeField] private float _angle = 0;

    public float Speed { get => _speed; set => _speed = value; }
    public float Angle { get => _angle; set => _angle = value; }

    private void Update()
    {
        // Set the Angle
        transform.rotation = Quaternion.Euler(0 ,0 , Angle + 180);

        // Move the Bullet
        transform.Translate(Vector3.up * (_speed / 10) * Time.deltaTime, Space.Self);
    }
}
