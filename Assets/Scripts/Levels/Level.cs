using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    public float speed = 1.0f;

    void Update()
    {
        transform.position += new Vector3(0, -1f, 0) * speed * Time.deltaTime;
    }

}
