using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootOnDeath : MonoBehaviour
{
    public GameObject shot;

    private void OnDestroy()
    {
        Instantiate(shot, transform.position, transform.rotation);
    }
}
