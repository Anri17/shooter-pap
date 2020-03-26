using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundCamera : MonoBehaviour
{
    public float speedModifier = 1f;

    void Update()
    {
        Vector3 direction = new Vector3(0, 0, 1 * speedModifier * Time.deltaTime);
        transform.Translate(direction);
    }
}
