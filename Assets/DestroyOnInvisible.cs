using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnInvisible : MonoBehaviour
{
    public GameObject destroyTarget;

    void OnBecameInvisible()
    {
        Debug.Log("Hello?!");
        Destroy(destroyTarget);
        Debug.Log(transform.position);
    }
}
