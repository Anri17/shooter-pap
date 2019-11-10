using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Events : MonoBehaviour
{
    [SerializeField]
    private GameObject[] spawnPoints;

    private void onTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayArea")
        {
            Debug.Log("Is in Play Area");
            foreach(GameObject point in spawnPoints)
            {
                point.SetActive(true);
            }
        }
    }
}
