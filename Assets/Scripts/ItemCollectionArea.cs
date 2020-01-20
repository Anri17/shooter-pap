using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollectionArea : MonoBehaviour
{
    [SerializeField] private GameObject[] itemsToCollect;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player"))
        {
            GameObject[] powerCollectables = GameObject.FindGameObjectsWithTag("PowerCollectable");
            GameObject[] bigPowerCollectables = GameObject.FindGameObjectsWithTag("BigPowerCollectable");
            GameObject[] scoreCollectables = GameObject.FindGameObjectsWithTag("ScoreCollectable");

            for (int i = 0; i < powerCollectables.Length; i++)
            {
                // Lerp Collectable to Player
            }
        }        
    }
}
