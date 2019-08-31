using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointToTarget : MonoBehaviour
{
    public GameObject target;
    private Vector3 direction;

    void Start()
    {
        direction = target.transform.position - transform.position;
        Debug.Log(direction);
        transform.rotation = Quaternion.LookRotation(direction);
    }
}
