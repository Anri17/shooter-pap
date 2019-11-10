using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnInvisible : MonoBehaviour
{
    public GameObject destroyTarget;

    void OnBecameInvisible()
    {
        Destroy(destroyTarget);
        if (destroyTarget == null)
            Destroy(gameObject);
    }
}
