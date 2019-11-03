using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateArround : MonoBehaviour
{
    public GameObject target;
    Vector3 newPosition;
    void Start()
    {

    }

    void FixedUpdate()
    {

        Vector3 direction = target.transform.position - transform.position;
        float angle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
        float distance = Vector3.Distance(target.transform.position, transform.position);
        newPosition = new Vector3(Mathf.Sin(angle), Mathf.Cos(angle), 0);
        transform.position += newPosition;
    }
}